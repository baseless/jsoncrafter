using System;
using System.Collections.Generic;
using JsonCrafter.ContentTypes.Hal.Interfaces;
using JsonCrafter.Conversion.Interfaces;
using JsonCrafter.Settings;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace JsonCrafter.Conversion.Hal
{
    public sealed class HalResourceConverter : ResourceConverterBase<ILogger<HalResourceConverter>>, IHalResourceConverter
    {
        public override string FormatName => JsonCrafterConstants.Hal.FormatName;
        public override string MediaTypeHeaderValue => JsonCrafterConstants.Hal.MediaTypeHeaderValue;

        public HalResourceConverter(IHalResourceContractBuilder builder, ILogger<HalResourceConverter> logger) : base(builder.Build(), logger)
        {
        }
        
        protected override JToken ConvertBase(JObject jsonObject, object obj, IResourceContract contract, bool isRoot = false)
        {
            foreach (var member in contract.Members)
            {
                if (member.IsResource)
                {
                    var resourceBase = contract.Template.NewResource(member, contract);
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
