using System;
using System.Collections.Generic;
using JsonCrafter.Contracts.Interfaces;
using JsonCrafter.MediaTypes.Hal.Interfaces;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace JsonCrafter.MediaTypes.Hal
{
    public sealed class HalJsonConverter : JsonConverterBase<IHalJsonConverter>, IHalJsonConverter
    {
        public override string FormatName => "hal+json";
        public override string MediaTypeHeaderValue => "application/hal+json";

        public HalJsonConverter(IContractResolver<IHalJsonConverter> resolver, ILogger<HalJsonConverter> logger) : base(resolver, logger) // todo: inject templatebuilder? (potentially make this class insensitive to mediatype)
        {
        }
        
        protected override JToken ConvertBase(JObject jsonObject, object obj, IContract contract, bool isRoot = false)
        {
            foreach (var member in contract.Members)
            {
                if (member.IsResource)
                {
                    var resourceBase = contract.Template.GetResourceBase(member, contract);
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
                    jsonObject.Add(new JProperty(member.Name, member.GetValueFromObject(obj)));
                    continue;
                }

                jsonObject.Add(new JProperty(member.Name, JToken.FromObject(member.GetValueFromObject(obj))));
            }

            return jsonObject;
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
