using System;
using JsonCrafter.Processing.Compilation.Hal;
using JsonCrafter.Processing.Contracts;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace JsonCrafter.Processing.Serialization.Hal
{
    public class HalSerializer : ResourceSerializerBase<HalSerializer>, IHalSerializer
    {
        public HalSerializer(IHalSettingsCompiler factory, ILogger<HalSerializer> logger) : base(factory, logger)
        {
        }

        public override string FormatName => HalSpecification.FormatName;

        public override string MediaTypeHeaderValue => HalSpecification.MediaTypeHeaderValue;

        protected override JToken ConvertBase(JObject target, Type type, object obj, IResourceContract contract, bool isRoot = false)
        {
            return JToken.FromObject(obj);
        }

        protected override JToken PostProcessResult(JToken token) => token;
    }
}
