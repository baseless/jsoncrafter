using System;
using JsonCrafter.Serialization.Build.Hal;
using JsonCrafter.Serialization.Contracts;
using JsonCrafter.Shared;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace JsonCrafter.Serialization.Converters.Hal
{
    public class HalConverter : ResourceConverterBase<HalConverter>, IHalConverter
    {
        public HalConverter(IHalResolverFactory factory, ILogger<HalConverter> logger) : base(factory, logger)
        {
        }

        public override string FormatName => JsonCrafterConstants.Hal.FormatName;

        public override string MediaTypeHeaderValue => JsonCrafterConstants.Hal.MediaTypeHeaderValue;

        protected override JToken ConvertBase(JObject target, Type type, object obj, IResourceContract contract, bool isRoot = false)
        {
            return JToken.FromObject(obj);
        }

        protected override JToken PostProcessResult(JToken token) => token;
    }
}
