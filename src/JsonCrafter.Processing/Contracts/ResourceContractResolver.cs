using System;

namespace JsonCrafter.Processing.Contracts
{
    public class ResourceContractResolver : IResourceContractResolver
    {
        public IResourceContract Resolve(Type type)
        {
            throw new NotImplementedException("Resolving contracts is not implemented yet!");
        }
    }
}
