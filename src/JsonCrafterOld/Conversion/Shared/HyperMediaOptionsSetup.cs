using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace JsonCrafterOld.Conversion.Shared
{
    public class HyperMediaOptionsSetup<TConverter> : IConfigureOptions<MvcOptions> where TConverter: HyperMediaOutputConverter<TConverter>
    {
        private readonly HyperMediaOutputConverter<TConverter> _converter;

        public HyperMediaOptionsSetup(HyperMediaOutputConverter<TConverter> converter)
        {
            _converter = converter ?? throw new ArgumentNullException(nameof(converter));
        }

        public void Configure(MvcOptions options)
        {
            if (string.IsNullOrEmpty(options.FormatterMappings.GetMediaTypeMappingForFormat(_converter.FormatName)))
            {
                options.FormatterMappings.SetMediaTypeMappingForFormat(_converter.FormatName, _converter.MediaTypeHeaderValue);
            }
            
            options.OutputFormatters.Add(new HyperMediaOutputFormatter<TConverter>(_converter));
        }
    }
}
