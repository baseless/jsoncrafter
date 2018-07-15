using Newtonsoft.Json.Linq;

namespace JsonCrafterOld.Serialization.Interfaces
{
    public interface IResourceConverter
    {
        string FormatName { get; }
        string MediaTypeHeaderValue { get; }

        JToken Convert(object obj);
    }
}
