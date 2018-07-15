using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using JsonCrafter.Configuration.Interfaces;
using JsonCrafter.Serialization.Interfaces;

namespace JsonCrafter.Serialization
{
    public class ResourceContract : IResourceContract
    {
        public IImmutableList<IResourceMember> Members { get; }
        public Type ContractedType { get; }
        public IResourceTemplate Template { get; }
        public bool HasTemplate { get; }

        public ResourceContract(Type type, IResourceTemplate template, IEnumerable<IResourceMember> members = default(IEnumerable<IResourceMember>))
        {
            Template = template;
            HasTemplate = template != default(IResourceTemplate);
            if(type == null || !type.IsClass)
            {
                throw new NotSupportedException("TypeContract only supports classes.");
            }

            ContractedType = type;
            Members = members?.ToImmutableList() ?? new List<IResourceMember>().ToImmutableList();
        }
    }
}
