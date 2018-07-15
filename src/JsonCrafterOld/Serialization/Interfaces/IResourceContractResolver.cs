using System;

namespace JsonCrafterOld.Serialization.Interfaces
{
    public interface IResourceContractResolver
    {
        IResourceContract Resolve(Type type);
    }
}
