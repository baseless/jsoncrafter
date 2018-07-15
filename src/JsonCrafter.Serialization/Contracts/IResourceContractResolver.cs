using System;

namespace JsonCrafter.Serialization.Contracts
{
    public interface IResourceContractResolver
    {
        IResourceContract Resolve(Type type);
    }
}
