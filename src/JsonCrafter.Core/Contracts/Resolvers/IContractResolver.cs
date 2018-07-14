using System;
using JsonCrafter.Core.Configuration;

namespace JsonCrafter.Core.Contracts
{
    public interface IContractResolver
    {
        void Build(Type type, ITypeContractTemplate template);
        ITypeContract Resolve(Type type);
    }
}
