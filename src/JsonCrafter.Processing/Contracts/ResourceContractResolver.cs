using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace JsonCrafter.Processing.Contracts
{
    public class ResourceContractResolver : IResourceContractResolver
    {
        public IImmutableDictionary<Type, IResourceContract> Contracts { get; }

        public ResourceContractResolver(IDictionary<Type, IResourceContract> contracts)
        {
            Contracts = contracts.ToImmutableDictionary();
        }
    }
}
