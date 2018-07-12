using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;

namespace JsonCrafter.Conversion.Hal
{
    public class HalOptionsSetup : IConfigureOptions<MvcOptions>
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly JsonConverter _converter;

        public HalOptionsSetup(ILoggerFactory loggerFactory, IConverter<HalOutputConverter> converter)
        {
            _loggerFactory = loggerFactory ?? throw new ArgumentNullException(nameof(loggerFactory));
            _converter = converter as JsonConverter ?? throw new ArgumentNullException(nameof(converter));
        }

        public void Configure(MvcOptions options)
        {
            if (string.IsNullOrEmpty(options.FormatterMappings.GetMediaTypeMappingForFormat(JsonCrafterConstants.Hal.Format)))
            {
                options.FormatterMappings.SetMediaTypeMappingForFormat(JsonCrafterConstants.Hal.Format,
                    JsonCrafterConstants.Hal.MediaTypeHeaderValue);
            }
            
            options.OutputFormatters.Add(new HyperMediaOutputFormatter(_loggerFactory, _converter, MediaTypeHeaderValue.Parse(JsonCrafterConstants.Hal.MediaTypeHeaderValue)));
        }
    }
}
