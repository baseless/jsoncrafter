using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Serialization;

namespace JsonCrafter.Build
{
    public interface IJsonCrafterConfiguratorFactory
    {
        bool Build(HttpContext context);
        IContractResolver Instance();
    }
}
