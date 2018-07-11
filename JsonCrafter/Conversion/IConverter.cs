using Newtonsoft.Json;

namespace JsonCrafter.Conversion
{
    public interface IConverter<TConverter> where TConverter: JsonConverter
    {
    }
}
