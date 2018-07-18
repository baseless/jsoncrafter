using System;

namespace JsonCrafter.Processing.Contracts
{
    public class ResourceContractResolver : IResourceContractResolver
    {
        public IResourceContract Resolve(Type type)
        {
            return new ResourceContract();
        }
    }
}
