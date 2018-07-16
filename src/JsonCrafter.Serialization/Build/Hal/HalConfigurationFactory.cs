using JsonCrafter.Configuration;
using JsonCrafter.Shared;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Serialization;
using System.Runtime.CompilerServices;

namespace JsonCrafter.Build.Hal
{
    public class HalConfigurationFactory : JsonCrafterConfiguratorBase, IHalConfigurationFactory
    {
        private readonly IJsonCrafterConfiguratorAction _configAction;
        private readonly IContractResolver _resolver;

        public HalConfigurationFactory(IJsonCrafterConfiguratorAction configAction)
        {
            _configAction = Ensure.IsSet(configAction);
        }

        public IContractResolver Instance() => _resolver;

        [MethodImpl(MethodImplOptions.Synchronized)] // todo: needed?
        public bool Build(HttpContext context)
        {
            Ensure.IsSet(context);
            return true;
        }
    }
}
