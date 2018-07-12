using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;

namespace JsonCrafter.Conversion.Hal
{
    public class HalOptionsSetup : IConfigureOptions<MvcOptions>
    {
        private readonly JsonConverter _converter;

        public HalOptionsSetup(IConverter<HalOutputConverter> converter)
        {
            _converter = converter as JsonConverter ?? throw new ArgumentNullException(nameof(converter));
        }

        public void Configure(MvcOptions options)
        {
            if (string.IsNullOrEmpty(options.FormatterMappings.GetMediaTypeMappingForFormat(JsonCrafterConstants.Hal.Format)))
            {
                options.FormatterMappings.SetMediaTypeMappingForFormat(JsonCrafterConstants.Hal.Format,
                    JsonCrafterConstants.Hal.MediaTypeHeaderValue);
            }
            
            options.OutputFormatters.Add(new HyperMediaOutputFormatter(_converter, MediaTypeHeaderValue.Parse(JsonCrafterConstants.Hal.MediaTypeHeaderValue)));
        }
    }
}
