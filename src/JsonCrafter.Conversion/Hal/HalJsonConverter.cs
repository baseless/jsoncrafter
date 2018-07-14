using System;
using System.Collections.Generic;
using JsonCrafter.Core.Contracts;
using JsonCrafter.Core.Contracts.Resolvers;
using Newtonsoft.Json.Linq;

namespace JsonCrafter.Conversion.Hal
{
    public sealed class HalJsonConverter : JsonConverterBase, IHalJsonConverter
    {
        public override string FormatName => "hal+json";
        public override string MediaTypeHeaderValue => "application/hal+json";

        public HalJsonConverter(IContractResolver resolver) : base(resolver) // todo: inject templatebuilder? (potentially make this class insensitive to mediatype)
        {
        }
        
        protected override JToken ConvertBase(JObject parent, object obj, ITypeContract contract, bool isRoot = false)
        {
            foreach (var member in contract.Members)
            {
                if (member.IsResource)
                {
                    var resourceBase = contract.Template.GetResourceObject(member, contract);
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
                    parent.Add(new JProperty(member.Name, member.GetValueFromObject(obj)));
                    continue;
                }

                parent.Add(new JProperty(member.Name, JToken.FromObject(member.GetValueFromObject(obj))));
            }

            return parent;
        }

        protected override JToken PostProcessResult(JToken token)
        {
            return token;
        }

        protected override JToken PostProcessRootCollection(IEnumerable<JToken> tokens)
        {
            throw new NotImplementedException();
        }
    }
}
