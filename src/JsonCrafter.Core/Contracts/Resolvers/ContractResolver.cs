using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JsonCrafter.Core.Configuration;
using JsonCrafter.Core.Helpers;

namespace JsonCrafter.Core.Contracts
{
    public class ContractResolver : IContractResolver
    {
        private static readonly ConcurrentDictionary<Type, ITypeContract> Contracts = new ConcurrentDictionary<Type, ITypeContract>();

        private readonly ITypeHelper _typeHelper;

        public ContractResolver(ITypeHelper typeHelper)
        {
            _typeHelper = typeHelper ?? throw new ArgumentNullException(nameof(typeHelper));
        }

        public void Build(Type type, ITypeContractTemplate template)
        {
            if (type == default(Type))
            {
                throw new ArgumentNullException(nameof(type));
            }

            if (template == default(ITypeContractTemplate))
            {
                throw new ArgumentNullException(nameof(template));
            }

            Contracts.AddOrUpdate(type, CreateContract(type, template), (k,v) => CreateContract(k, template));
        }

        public ITypeContract Resolve(Type type)
        {
            if (type == default(Type))
            {
                throw new ArgumentNullException(nameof(type));
            }

            return Contracts.GetOrAdd(type, t => CreateContract(t)); // todo: build in option if non-existing contracts should case throw or be created without template on-the-fly.
        }

        internal ITypeContract CreateContract(Type type, ITypeContractTemplate template = default(ITypeContractTemplate))
        {
            var members = _typeHelper.GetMembers(type);
            var contracts = CreateMemberContracts(type, members);

            return new TypeContract(type, template, contracts);
        }

        internal IEnumerable<IMemberContract> CreateMemberContracts(Type type, IEnumerable<MemberInfo> members)
        {
            var result = new List<IMemberContract>();

            foreach (var member in members)
            {
                if (member.MemberType.Equals(MemberTypes.Field) && member is FieldInfo field)
                {
                    result.Add(new FieldContract(field.Name, field));
                    continue;
                }

                if (member.MemberType.Equals(MemberTypes.Property) && member is PropertyInfo prop)
                {
                    result.Add(new PropertyContract(prop.Name, prop));
                    continue;
                }
                
                throw new JsonCrafterException($"Failed to parse membercontract for member '{member.GetType().FullName}' from type '{type.FullName}' (could not be cast to PropertyInfo or FieldInfo).");
            }

            return result;
        }
    }
}
