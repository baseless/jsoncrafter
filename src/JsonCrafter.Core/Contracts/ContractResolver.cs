using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using JsonCrafter.Core.Configuration.Interfaces;
using JsonCrafter.Core.Contracts.Interfaces;
using JsonCrafter.Core.Helpers;

namespace JsonCrafter.Core.Contracts
{
    public class ContractResolver<TConverter> : IContractResolver<TConverter> where TConverter: IJsonConverter
    {
        /// <summary>
        /// All processed typecontracts.
        /// </summary>
        private static readonly ConcurrentDictionary<Type, IContract> Contracts = new ConcurrentDictionary<Type, IContract>();

        /// <summary>
        /// A default, normally empty / minimal template, for types that is registered at runtime (which means they has no rules set).
        /// </summary>
        private static ITypeTemplate DefaultTemplate;

        public ContractResolver(IDictionary<Type, ITypeTemplate> contractRequests, ITypeTemplate defaultTemplate)
        {
            DefaultTemplate = defaultTemplate ?? throw new ArgumentNullException(nameof(defaultTemplate));

            if (contractRequests == default(IDictionary<Type, ITypeTemplate>))
            {
                throw new ArgumentNullException(nameof(contractRequests));
            }

            foreach (var request in contractRequests)
            {
                Contracts.AddOrUpdate(request.Key, CreateContract(request.Key, request.Value), (k, v) => CreateContract(k, request.Value));
            }
        }
        
        public IContract Resolve(Type type)
        {
            if (type == default(Type))
            {
                throw new ArgumentNullException(nameof(type));
            }

            return Contracts.GetOrAdd(type, t => CreateContract(t, DefaultTemplate)); // todo: build in option if non-existing contracts should case throw or be created without template on-the-fly.
        }

        internal IContract CreateContract(Type type, ITypeTemplate template)
        {
            var members = TypeHelper.GetMembers(type);
            var contracts = CreateMemberContracts(type, members);

            return new Contract(type, template, contracts);
        }

        internal IEnumerable<IMember> CreateMemberContracts(Type type, IEnumerable<MemberInfo> members)
        {
            var result = new List<IMember>();

            foreach (var member in members)
            {
                if (member.MemberType.Equals(MemberTypes.Field) && member is FieldInfo field)
                {
                    result.Add(new Field(field.Name, field));
                    continue;
                }

                if (member.MemberType.Equals(MemberTypes.Property) && member is PropertyInfo prop)
                {
                    result.Add(new Property(prop.Name, prop));
                    continue;
                }
                
                throw new JsonCrafterException($"Failed to parse membercontract for member '{member.GetType().FullName}' from type '{type.FullName}' (could not be cast to PropertyInfo or FieldInfo).");
            }

            return result;
        }
    }
}
