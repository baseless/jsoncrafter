using System;

namespace JsonCrafter.Serialization.Interfaces
{
    public interface IResourceContractResolver
    {
        IResourceContract Resolve(Type type);
    }
}
