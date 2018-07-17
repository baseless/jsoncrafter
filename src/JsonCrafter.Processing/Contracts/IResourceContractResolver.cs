using System;

namespace JsonCrafter.Processing.Contracts
{
    public interface IResourceContractResolver
    {
        IResourceContract Resolve(Type type);
    }
}
