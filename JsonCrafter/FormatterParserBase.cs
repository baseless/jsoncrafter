using System.Linq;
using JsonCrafter.Interfaces;
using Newtonsoft.Json.Linq;

namespace JsonCrafter
{
    public abstract class FormatterParserBase<TOutputFormatter> : IFormatterParser<TOutputFormatter>
    {
        public ParserResult Parse(JObject obj)
        {
            return ParseBase(obj) ? ParserResult.Success(obj.ToString()) : ParserResult.Failure();
        }

        public ParserResult Parse(JArray arr)
        {
            return arr.Where(o => o.Type.Equals(JTokenType.Object)).Cast<JObject>().Any(obj => !ParseBase(obj)) 
                ? ParserResult.Failure() 
                : ParserResult.Success(arr.ToString());
        }

        protected abstract bool ParseBase(JObject obj);
    }
}
