using System.Collections.Generic;
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

        public HalJsonConverter(ITokenConverter tokenConverter, IContractResolver resolver) : base(tokenConverter, resolver, new HalTemplateBuilder()) // todo: inject templatebuilder? (potentially make this class insensitive to mediatype)
        {
        }
        
        protected override JToken ConvertBase(JObject parent, object obj, ITypeContract contract, bool isRoot = false)
        {
            BuildObject(parent, obj, contract, isRoot);
            return parent;
        }

        private void BuildObject(JObject objectBase, object obj, ITypeContract contract, bool isRoot)
        {
            foreach (var member in contract.Members)
            {
                if (member.IsResource)
                {
                    var resourceBase = TemplateBuilder.BuildResource(member, contract);
                    if (member.IsCollection)
                    {
                        // todo: create resources and traverse recursively
                    }
                    else
                    {
                        // todo: create resources and traverse recursively
                    }
                }

                if (member.IsValue)
                {
                    objectBase.Add(new JProperty(member.Name, member.GetValueFromObject(obj)));
                    continue;
                }

                objectBase.Add(new JProperty(member.Name, JToken.FromObject(member.GetValueFromObject(obj))));
            }
        }

        protected override JToken PostProcessRootCollection(IEnumerable<JToken> tokens)
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
