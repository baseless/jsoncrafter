using JsonCrafter.Interfaces;
using Microsoft.Extensions.Logging;

namespace JsonCrafter.MediaTypes.Hal
{
    public class HalOutputFormatter : HyperMediaOutputFormatterBase<HalOutputFormatter>
    {
        public HalOutputFormatter(ILoggerFactory loggerFactory, IFormatterParser<HalOutputFormatter> parser) : base(loggerFactory, parser, JsonCrafterConstants.Hal.MediaTypeHeaderValue)
        {
        }
    }
}
