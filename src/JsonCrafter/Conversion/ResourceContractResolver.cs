using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using JsonCrafter.Configuration.Interfaces;
using JsonCrafter.Conversion.Interfaces;
using JsonCrafter.Core;
using JsonCrafter.Helpers;

namespace JsonCrafter.Conversion
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

        public ResourceContractResolver(IDictionary<Type, IResourceTemplate> contractRequests, IResourceTemplate defaultTemplate, ICollection<Type> resourceTypes)
        {
            _defaultTemplate = defaultTemplate ?? throw new ArgumentNullException(nameof(defaultTemplate));

            if (contractRequests == default(IDictionary<Type, IResourceTemplate>))
            {
                throw new ArgumentNullException(nameof(contractRequests));
            }

            foreach (var request in contractRequests)
            {
                _contracts.AddOrUpdate(
                    request.Key, 
                    CreateContract(request.Key, request.Value, resourceTypes), 
                    (k, v) => throw new JsonCrafterException($"Encounterd duplicates when constructing Resolver (tried to create contract for {request.Key.FullName})")
                );
            }
        }
        
        public IResourceContract Resolve(Type type)
        {
            if (type == default(Type))
            {
                throw new ArgumentNullException(nameof(type));
            }
            
            return _contracts.GetOrAdd(type, t => CreateContract(t, _defaultTemplate));
        }

        internal IResourceContract CreateContract(Type type, IResourceTemplate template, ICollection<Type> resourceTypes = null)
        {
            var members = TypeHelper.GetMembers(type);
            var contracts = CreateMemberContracts(type, members, resourceTypes);

            return new ResourceContract(type, template, contracts);
        }

        internal IEnumerable<IResourceMember> CreateMemberContracts(Type type, IEnumerable<MemberInfo> members, ICollection<Type> resourceTypes)
        {
            var result = new List<IResourceMember>();
            foreach (var member in members)
            {
                if (member.MemberType.Equals(MemberTypes.Field) && member is FieldInfo field)
                {
                    var isRelatedResource = resourceTypes != null && resourceTypes.Contains(field.FieldType);
                    result.Add(new ResourceField(field.Name, field, isRelatedResource));
                    continue;
                }

                if (member.MemberType.Equals(MemberTypes.Property) && member is PropertyInfo prop)
                {
                    var isRelatedResource = resourceTypes != null && resourceTypes.Contains(prop.PropertyType);
                    result.Add(new ResourceProperty(prop.Name, prop, isRelatedResource));
                    continue;
                }
                
                throw new JsonCrafterException($"Failed to parse membercontract for member '{member.GetType().FullName}' from type '{type.FullName}' (could not be cast to PropertyInfo or FieldInfo).");
            }

            return result;
        }
    }
}
