using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using JsonCrafter.Processing.Contracts.Items;

namespace JsonCrafter.Processing.Contracts
{
    public class TypeContractResolver : ITypeContractResolver
    {
        public IImmutableDictionary<Type, IJsonContract> Contracts { get; }

        public TypeContractResolver(IDictionary<Type, IJsonContract> contracts)
        {
            Contracts = contracts.ToImmutableDictionary();
        }
    }
}
