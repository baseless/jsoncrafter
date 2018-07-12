using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JsonCrafter.Conversion.Hal;
using JsonCrafter.Reflection;
using JsonCrafter.Rules;
using JsonCrafter.Rules.Parsed;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonCrafter.Conversion
{
    public abstract class OutputConverterBase : JsonConverter, IConverter<HalOutputConverter>
    {
        protected readonly IRuleCollection Rules;
        protected readonly IJsonCrafterReflectionService ReflectionService;

        protected OutputConverterBase(IRuleCollection ruleSet)
        {
            Rules = ruleSet ?? throw new ArgumentNullException(nameof(ruleSet));
            ReflectionService = new JsonCrafterReflectionService();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) =>
            throw new NotImplementedException();

        public override bool CanRead => 
            false;

        public override bool CanConvert(Type objectType) => 
            true;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var objectType = value.GetType();
            
            var token = JToken.FromObject(value);

            if(token.Type.Equals(JTokenType.Object) && token is JObject obj)
            {
                FormatObject(objectType, obj, serializer);
            }
            else if (token.Type.Equals(JTokenType.Array) && token is JArray arr)
            {
                foreach (var o in arr.Where(t => t.Type.Equals(JTokenType.Object)).Cast<JObject>())
                {
                    FormatObject(objectType, o, serializer);
                }
            }

            token.WriteTo(writer);
        }

        protected abstract void FormatObject(Type type, JObject jsonObject, JsonSerializer serializer);
    }
}
