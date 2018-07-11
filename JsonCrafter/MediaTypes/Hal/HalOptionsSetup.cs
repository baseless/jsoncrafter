using System;
using JsonCrafter.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace JsonCrafter.MediaTypes.Hal
{
    public class HalOptionsSetup : IConfigureOptions<MvcOptions>
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly IFormatterParser<HalOutputFormatter> _halParser;

        public HalOptionsSetup(ILoggerFactory loggerFactory, IFormatterParser<HalOutputFormatter> halParser)
        {
            _loggerFactory = loggerFactory ?? throw new ArgumentNullException(nameof(loggerFactory));
            _halParser = halParser ?? throw new ArgumentNullException(nameof(halParser));
        }

        public void Configure(MvcOptions options)
        {
            if (string.IsNullOrEmpty(options.FormatterMappings.GetMediaTypeMappingForFormat(JsonCrafterConstants.Hal.Format)))
            {
                options.FormatterMappings.SetMediaTypeMappingForFormat(JsonCrafterConstants.Hal.Format,
                    JsonCrafterConstants.Hal.MediaTypeHeaderValue);
            }
            
            options.OutputFormatters.Add(new HalOutputFormatter(_loggerFactory, _halParser));
        }
    }
}
