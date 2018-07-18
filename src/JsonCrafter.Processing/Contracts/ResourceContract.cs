using System;
using System.Collections.Immutable;
using JsonCrafter.Processing.Contracts.Members;

namespace JsonCrafter.Processing.Contracts
{
    public class ResourceContract : IResourceContract
    {
        public IImmutableList<IContractMember> Members { get; }
        public Type ContractedType { get; }
        public IResourceTemplate Template { get; }
        public bool HasTemplate { get; }
    }
}
