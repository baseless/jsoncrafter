using System;
using JsonCrafter.Core.Configuration;

namespace JsonCrafter.Core.Contracts.Resolvers
{
    public interface IContractResolver
    {
        void Build(Type type, ITypeTemplate template);
        ITypeContract Resolve(Type type);
    }
}
