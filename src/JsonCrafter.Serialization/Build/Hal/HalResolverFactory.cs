using System.Runtime.CompilerServices;
using JsonCrafter.Serialization.Configuration;
using JsonCrafter.Shared;
using Newtonsoft.Json.Serialization;

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
        public IContractResolver Create()
        {
            return null;
        }
    }
}
