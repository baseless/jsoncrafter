using System;
using System.Collections.Immutable;
using JsonCrafter.Core.Configuration;

namespace JsonCrafter.Core.Contracts
{
    public interface ITypeContract
    {
        /// <summary>
        /// List of all public properties, fields, objects and collections contained by the type.
        /// </summary>
        IImmutableList<IMemberContract> Members { get; }
        /// <summary>
        /// The C# type on which the contract is built.
        /// </summary>
        Type ContractedType { get; }
        /// <summary>
        /// The template for the type (containing data regarding for example links).
        /// </summary>
        ITypeTemplate Template { get; }
        /// <summary>
        /// A helper property to check if this type has a bound template.
        /// </summary>
        bool HasTemplate { get; }
    }
}
