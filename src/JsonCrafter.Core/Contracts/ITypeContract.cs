using System;
using System.Collections.Immutable;
using JsonCrafter.Core.Contracts;

namespace JsonCrafter.Core
{
    /// <summary>
    /// Represents a C# Type, soon-to-be Json Object.
    /// ADoes not have a name (since if it is a child it get its name from the parent TypeContract).
    /// </summary>
    public interface ITypeContract
    {
        IImmutableDictionary<string, IFieldContract> Fields { get; }
        Type ContractedType { get; }
    }
}
