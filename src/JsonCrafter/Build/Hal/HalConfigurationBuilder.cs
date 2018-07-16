using JsonCrafter.Configuration;
using JsonCrafter.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newtonsoft.Json.Serialization;

namespace JsonCrafter.Build.Hal
{
    public class HalConfigurationBuilder : JsonCrafterConfiguratorBase, IHalConfigurationBuilder
    {
        private readonly IJsonCrafterConfiguratorAction _configAction;
        private readonly IHttpContextAccessor _contextAccessor;

        public HalConfigurationBuilder(IJsonCrafterConfiguratorAction configAction, IHttpContextAccessor contextAccessor)
        {
            _configAction = Ensure.IsSet(configAction);
            _contextAccessor = Ensure.IsSet(contextAccessor);
        }

        public IContractResolver Build(IActionContextAccessor actionContext, IJsonCrafterConfigurator configurator)
        {
            throw new System.NotImplementedException();
        }
    }
}
