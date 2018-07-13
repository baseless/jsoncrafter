using System.Collections.Generic;
using System.Linq;
using JsonCrafter.Conversion.Shared;
using JsonCrafter.Core;
using JsonCrafter.Core.Contracts;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json.Linq;

namespace JsonCrafter.Conversion.Hal
{
    public class HalJsonConverter : JsonConverterBase, IHalJsonConverter
    {
        public override string FormatName => "hal+json";
        public override string MediaTypeHeaderValue => "application/hal+json";

        public HalJsonConverter(ITokenConverter tokenConverter, IContractResolver resolver) : base(tokenConverter, resolver)
        {
        }

        protected override JToken ConvertObject(object obj, ITypeContract contract)
        {
            var f = contract.Fields.First();
            var val = f.Value.ContractedFieldInfo.GetValue(obj);

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
