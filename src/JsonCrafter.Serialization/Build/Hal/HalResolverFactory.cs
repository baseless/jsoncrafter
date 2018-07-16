using System.Runtime.CompilerServices;
using JsonCrafter.Serialization.Configuration;
using JsonCrafter.Serialization.Contracts;
using JsonCrafter.Shared;

namespace JsonCrafter.Serialization.Build.Hal
{
    public class HalResolverFactory : JsonCrafterConfiguratorBase, IHalResolverFactory
    {
        private readonly IJsonCrafterConfiguratorAction _configAction;

        public HalResolverFactory(IJsonCrafterConfiguratorAction configAction)
        {
            _configAction = Ensure.IsSet(configAction);
        }
        

        [MethodImpl(MethodImplOptions.Synchronized)] // todo: needed?
        public IResourceContractResolver Create()
        {
            // 1. Validate all resource setting based on hal rules
            // 2. Build all related
            // 3. Build and return resolver
            return new ResourceContractResolver();
        }
    }
}
