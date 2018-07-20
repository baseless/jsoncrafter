using System;
using System.Collections.Immutable;
using JsonCrafter.Processing.Contracts.Items;

namespace JsonCrafter.Processing.Contracts
{
    public interface ITypeContractResolver
    {
        IImmutableDictionary<Type, IJsonContract> Contracts { get; }
    }
}
