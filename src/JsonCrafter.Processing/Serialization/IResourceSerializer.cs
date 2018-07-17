using Newtonsoft.Json.Linq;

namespace JsonCrafter.Processing.Serialization
{
    public interface IResourceSerializer
    {
        string FormatName { get; }
        string MediaTypeHeaderValue { get; }

        JToken Convert(object obj);
    }
}
