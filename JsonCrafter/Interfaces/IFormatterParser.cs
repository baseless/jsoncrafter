using Newtonsoft.Json.Linq;

namespace JsonCrafter.Interfaces
{
    public interface IFormatterParser<TFormatter>
    {
        ParserResult Parse(JObject obj);
        ParserResult Parse(JArray arr);
    }
}
