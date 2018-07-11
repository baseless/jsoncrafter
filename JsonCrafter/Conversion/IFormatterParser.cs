using JsonCrafter.DTO;
using Newtonsoft.Json.Linq;

namespace JsonCrafter.Conversion
{
    public interface IFormatterParser<TFormatter>
    {
        ParserResult Parse(JObject obj);
        ParserResult Parse(JArray arr);
    }
}
