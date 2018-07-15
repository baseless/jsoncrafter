using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using JsonCrafter.Configuration.Interfaces;
using JsonCrafter.Conversion.Interfaces;
using JsonCrafter.Helpers;

namespace JsonCrafter.ContentTypes
{
    public class ResourceContractResolver : IResourceContractResolver
    {
        /// <summary>
        /// All processed typecontracts.
        /// </summary>
        private readonly ConcurrentDictionary<Type, IResourceContract> _contracts = new ConcurrentDictionary<Type, IResourceContract>();

        /// <summary>
        /// A default, normally empty / minimal template, for types that is registered at runtime (which means they has no rules set).
        /// </summary>
        private readonly IResourceTemplate _defaultTemplate;

        public ResourceContractResolver(IDictionary<Type, IResourceTemplate> contractRequests, IResourceTemplate defaultTemplate)
        {
            _defaultTemplate = defaultTemplate ?? throw new ArgumentNullException(nameof(defaultTemplate));

            if (contractRequests == default(IDictionary<Type, IResourceTemplate>))
            {
                throw new ArgumentNullException(nameof(contractRequests));
            }

            foreach (var request in contractRequests)
            {
                _contracts.AddOrUpdate(request.Key, CreateContract(request.Key, request.Value), (k, v) => CreateContract(k, request.Value));
            }
        }
        
        public IResourceContract Resolve(Type type)
        {
            if (type == default(Type))
            {
                throw new ArgumentNullException(nameof(type));
            }

            return _contracts.GetOrAdd(type, t => CreateContract(t, _defaultTemplate)); // todo: build in option if non-existing contracts should case throw or be created without template on-the-fly.
        }

        internal IResourceContract CreateContract(Type type, IResourceTemplate template)
        {
            var members = TypeHelper.GetMembers(type);
            var contracts = CreateMemberContracts(type, members);

            return new ResourceContract(type, template, contracts);
        }

        internal IEnumerable<IResourceMember> CreateMemberContracts(Type type, IEnumerable<MemberInfo> members)
        {
            var result = new List<IResourceMember>();

            foreach (var member in members)
            {
                if (member.MemberType.Equals(MemberTypes.Field) && member is FieldInfo field)
                {
                    result.Add(new ResourceField(field.Name, field));
                    continue;
                }

                if (member.MemberType.Equals(MemberTypes.Property) && member is PropertyInfo prop)
                {
                    result.Add(new ResourceProperty(prop.Name, prop));
                    continue;
                }
                
                throw new JsonCrafterException($"Failed to parse membercontract for member '{member.GetType().FullName}' from type '{type.FullName}' (could not be cast to PropertyInfo or FieldInfo).");
            }

            return result;
        }
    }
}
