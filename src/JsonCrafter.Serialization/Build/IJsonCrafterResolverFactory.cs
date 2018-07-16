using Newtonsoft.Json.Serialization;

namespace JsonCrafter.Serialization.Build
{
    public interface IJsonCrafterResolverFactory
    {
        IContractResolver Create();
    }
}
