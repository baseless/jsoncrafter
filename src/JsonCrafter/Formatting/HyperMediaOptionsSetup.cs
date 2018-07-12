using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;

namespace JsonCrafter.Formatting
{
    public class HyperMediaOptionsSetup<TConverter> : IOptionsSetup<MvcOptions> where TConverter: JsonConverter
    {
        private readonly JsonConverter _converter;
        private readonly string _format;
        private readonly string _mediaTypeHeaderValue;

        public HyperMediaOptionsSetup(IConverter<TConverter> converter, string format, string mediaTypeHeaderValue)
        {
            _converter = converter as JsonConverter ?? throw new ArgumentNullException(nameof(converter));
            _format = format ?? throw new ArgumentNullException(nameof(format));
            _mediaTypeHeaderValue = mediaTypeHeaderValue ?? throw new ArgumentNullException(nameof(mediaTypeHeaderValue));
        }

        public void Configure(MvcOptions options)
        {
            if (string.IsNullOrEmpty(options.FormatterMappings.GetMediaTypeMappingForFormat(_format)))
            {
                options.FormatterMappings.SetMediaTypeMappingForFormat(_format, _mediaTypeHeaderValue);
            }
            
            options.OutputFormatters.Add(new HyperMediaOutputFormatter(_converter, MediaTypeHeaderValue.Parse(_mediaTypeHeaderValue)));
        }
    }
}
