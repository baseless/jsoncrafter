using System.Collections.Generic;
using JsonCrafter.Core.Handlers;
using Newtonsoft.Json.Linq;

namespace JsonCrafter.Conversion.Hal
{
    public class HalJsonConverter : JsonConverterBase, IHalJsonConverter
    {
        public override string FormatName => "hal+json";
        public override string MediaTypeHeaderValue => "application/hal+json";

        public HalJsonConverter(ITypeHandler typeHandler) : base(typeHandler)
        {
        }

        protected override JToken ConvertObject(object obj)
        {
            return JToken.FromObject(obj);
        }

        protected override JToken PostProcessEnumerable(IEnumerable<JToken> tokens)
        {
            var rootToken = new JObject { new JProperty("data", tokens) };
            return rootToken;
        }

        protected override JToken PostProcessResult(JToken token)
        {
            return token;
        }
    }
}
