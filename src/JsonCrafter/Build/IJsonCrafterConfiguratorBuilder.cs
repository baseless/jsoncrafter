using JsonCrafter.Configuration;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newtonsoft.Json.Serialization;

namespace JsonCrafter.Build
{
    public interface IJsonCrafterConfiguratorBuilder
    {
        IContractResolver Build(IActionContextAccessor actionContext, IJsonCrafterConfigurator configurator);
    }
}
