using System;
using JsonCrafter.Processing.Compilation.Hal;
using JsonCrafter.Processing.Contracts;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace JsonCrafter.Processing.Serialization.Hal
{
    /// <summary>
    /// Responsible for serializing response objects into HAL Json.
    /// </summary>
    public class HalSerializer : ResourceSerializerBase<HalSerializer>, IHalSerializer
    {
        public HalSerializer(IHalConfigurationCompiler factory, ILogger<HalSerializer> logger) : base(factory, logger)
        {
        }

        /// <inheritdoc />
        public override string FormatName => HalSpecification.FormatName;


        /// <inheritdoc />
        public override string MediaTypeHeaderValue => HalSpecification.MediaTypeHeaderValue;

        /// <inheritdoc />
        protected override JToken ConvertResource(JObject target, Type type, object obj, IResourceContract contract, bool isRoot = false)
        {
            return JToken.FromObject(obj);
        }

        /// <inheritdoc />
        protected override JToken PostProcessResponseToken(JToken token) => token;
    }
}
