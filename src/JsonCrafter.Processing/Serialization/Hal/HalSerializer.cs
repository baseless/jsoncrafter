using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
    }
}
