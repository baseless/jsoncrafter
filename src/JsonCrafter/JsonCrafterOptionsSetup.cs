using System;
using JsonCrafter.Configuration.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace JsonCrafter
{
    internal class JsonCrafterOptionsSetup<TConverter> : IConfigureOptions<MvcOptions> where TConverter: class, IJsonConverter
    {
        private readonly TConverter _converter;

        internal JsonCrafterOptionsSetup(TConverter converter)
        {
            _converter = converter ?? throw new NotImplementedException(nameof(converter));
        }

        public void Configure(MvcOptions options)
        {
            if (string.IsNullOrEmpty(options.FormatterMappings.GetMediaTypeMappingForFormat(_converter.FormatName)))
            {
                options.FormatterMappings.SetMediaTypeMappingForFormat(_converter.FormatName, _converter.MediaTypeHeaderValue);
            }

            options.OutputFormatters.Add(new JsonCrafterOutputFormatter<TConverter>(_converter));
        }
    }
}
