using JsonCrafter.Serialization.Build;
using Newtonsoft.Json.Linq;

namespace JsonCrafter.Serialization.Converters
{
    public interface IResourceConverter
    {
        string FormatName { get; }
        string MediaTypeHeaderValue { get; }

        JToken Convert(object obj);
        IJsonCrafterResolverFactory ConfigurationFactory { get; }
    }
}
