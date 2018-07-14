using System.Collections.Generic;
using System.Linq;
using JsonCrafter.Conversion.Shared;
using JsonCrafter.Core.Contracts;
using JsonCrafter.Core.Contracts.Resolvers;
using Newtonsoft.Json.Linq;

namespace JsonCrafter.Conversion.Hal
{
    public sealed class HalJsonConverter : JsonConverterBase, IHalJsonConverter
    {
        public override string FormatName => "hal+json";
        public override string MediaTypeHeaderValue => "application/hal+json";

        public HalJsonConverter(ITokenConverter tokenConverter, IContractResolver resolver) : base(tokenConverter, resolver)
        {
        }
        
        protected override JToken ConvertObject(object obj, ITypeContract contract)
        {
            var f = contract.Members.FirstOrDefault();
            var val = f?.GetValueFromObject(obj);
            
            return BuildToken(obj, contract);
        }

        private static JToken BuildToken(object obj, ITypeContract contract)
        {
            var root = JObject.Parse("{}");

            foreach (var member in contract.Members)
            {
                if (member.IsResource)
                {

                }

                if (member.IsValue)
                {
                    root.Add(new JProperty(member.Name, member.GetValueFromObject(obj)));
                    continue;
                }

                root.Add(new JProperty(member.Name, JToken.FromObject(member.GetValueFromObject(obj))));
            }

            return root;
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
