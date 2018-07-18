using System;
using System.Collections.Immutable;

namespace JsonCrafter.Processing.Contracts
{
    public interface IResourceContractResolver
    {
        IImmutableDictionary<Type, IResourceContract> Contracts { get; }
    }
}
