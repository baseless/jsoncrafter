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
        public ITypeContractTemplate Template { get; }
        public bool HasTemplate { get; }

        public TypeContract(Type type, ITypeContractTemplate template, IEnumerable<IMemberContract> members = default(IEnumerable<IMemberContract>))
        {
            Template = template;
            HasTemplate = template != default(ITypeContractTemplate);
            if(type == null || !type.IsClass || type.IsAbstract)
            {
                throw new NotSupportedException("TypeContract only supports non-abstract classes.");
            }

            ContractedType = type;
            Members = members?.ToImmutableList() ?? new List<IMemberContract>().ToImmutableList();
        }
    }
}
