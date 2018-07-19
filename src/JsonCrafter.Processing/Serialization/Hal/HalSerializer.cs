using System;
using JsonCrafter.Processing.Compilation.Hal;
using JsonCrafter.Processing.Contracts;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

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
        protected override void WriteTopLevelObject(JsonTextWriter writer, Type type, object instance, IResourceContract contract)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        protected override void WriteTopLevelArray(JsonTextWriter writer, Type type, object instance, IResourceContract contract)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        protected override void WriteErrorResponse(JsonTextWriter writer, Type type, object instance)
        {
            throw new NotImplementedException();
        }
    }
}
