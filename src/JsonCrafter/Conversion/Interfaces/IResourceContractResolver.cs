using System;

namespace JsonCrafter.Conversion.Interfaces
{
    public interface IResourceContractResolver
    {
        IResourceContract Resolve(Type type);
    }
}
