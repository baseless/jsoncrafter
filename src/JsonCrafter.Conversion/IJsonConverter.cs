using Newtonsoft.Json.Linq;

namespace JsonCrafter.Conversion
{
    public interface IJsonConverter
    {
        string FormatName { get; }
        string MediaTypeHeaderValue { get; }

        JToken Convert(object obj);
    }
}
