using System;
using System.Collections.Immutable;
using JsonCrafter.Core.Contracts;
using System.Collections.Generic;

namespace JsonCrafter.Core
{
    public class TypeContract : ITypeContract
    {
        public IImmutableDictionary<string, IFieldContract> Fields { get; }
        public Type ContractedType { get; }

        public TypeContract(Type type, IDictionary<string, IFieldContract> fields = default(IDictionary<string, IFieldContract>))
        {
            if(type == null || !type.IsClass || type.IsAbstract)
            {
                throw new NotSupportedException("TypeContract only supports non-abstract classes.");
            }

            ContractedType = type;
            Fields = fields?.ToImmutableDictionary() ?? new Dictionary<string, IFieldContract>().ToImmutableDictionary();
        }
    }
}
