using System;
using JsonCrafter.Rules;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonCrafter.Conversion.Hal
{
    public class HalJsonConverter : JsonConverter, IConverter<HalJsonConverter>
    {
        private readonly IJsonRuleSet _ruleSet;

        public HalJsonConverter(IJsonRuleSet ruleSet)
        {
            _ruleSet = ruleSet ?? throw new ArgumentNullException(nameof(ruleSet));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var objectType = value.GetType();

            var token = JToken.FromObject(value);

            if (token.Type.Equals(JTokenType.Object) && token is JObject o)
            {
                o.Add("fewghre", "grehtrejhtrjtr");
                o.WriteTo(writer);
            }
            else
            {
                token.WriteTo(writer);
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return existingValue;
        }

        public override bool CanRead => false;

        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
}
