using System;

namespace JsonCrafter.Core.Contracts
{
    public interface IContractResolver
    {
        ITypeContract Resolve(Type type);
    }
}
