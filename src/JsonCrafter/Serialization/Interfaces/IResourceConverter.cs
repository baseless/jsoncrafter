using Newtonsoft.Json.Linq;

namespace JsonCrafter.Serialization.Interfaces
{
    public interface IResourceConverter
    {
        string FormatName { get; }
        string MediaTypeHeaderValue { get; }

        JToken Convert(object obj);
    }
}
