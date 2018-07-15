using System;

namespace JsonCrafter.Serialization.Contracts
{
    public interface IContractResolver
    {
        IContract Resolve(Type type);
    }
}
