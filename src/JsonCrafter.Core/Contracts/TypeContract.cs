using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using JsonCrafter.Core.Configuration;

namespace JsonCrafter.Core.Contracts
{
    public class TypeContract : ITypeContract
    {
        public IImmutableList<IMemberContract> Members { get; }
        public Type ContractedType { get; }
        public ITypeTemplate Template { get; }
        public bool HasTemplate { get; }

        public TypeContract(Type type, ITypeTemplate template, IEnumerable<IMemberContract> members = default(IEnumerable<IMemberContract>))
        {
            Template = template;
            HasTemplate = template != default(ITypeTemplate);
            if(type == null || !type.IsClass || type.IsAbstract)
            {
                throw new NotSupportedException("TypeContract only supports non-abstract classes.");
            }

            ContractedType = type;
            Members = members?.ToImmutableList() ?? new List<IMemberContract>().ToImmutableList();
        }
    }
}
