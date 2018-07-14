using Newtonsoft.Json.Linq;

namespace JsonCrafter.Core.Configuration.Interfaces
{
    public interface IJsonConverter
    {
        string FormatName { get; }
        string MediaTypeHeaderValue { get; }

        JToken Convert(object obj);
    }
}
