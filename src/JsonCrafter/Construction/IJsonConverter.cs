using Newtonsoft.Json.Linq;

namespace JsonCrafter.Construction
{
    public interface IJsonConverter
    {
        string FormatName { get; }
        string MediaTypeHeaderValue { get; }

        JToken Convert(object obj);
    }
}
