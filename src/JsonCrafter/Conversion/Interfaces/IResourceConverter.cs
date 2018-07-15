using Newtonsoft.Json.Linq;

namespace JsonCrafter.Conversion.Interfaces
{
    public interface IResourceConverter
    {
        string FormatName { get; }
        string MediaTypeHeaderValue { get; }

        JToken Convert(object obj);
    }
}
