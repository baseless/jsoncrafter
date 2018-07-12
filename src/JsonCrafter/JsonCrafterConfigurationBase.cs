using System.Collections.Generic;
using System.Collections.Immutable;
using JsonCrafter.Appendices;
using JsonCrafter.Formatting;

namespace JsonCrafter
{
    public abstract class JsonCrafterConfigurationBase : IFormatterConfiguration
    {
        public ImmutableArray<string> SupportedMediaTypes { get; }

        protected JsonCrafterConfigurationBase(IEnumerable<string> supportedMediaTypes = default(IEnumerable<string>))
        {
            SupportedMediaTypes = supportedMediaTypes?.ToImmutableArray() ?? new ImmutableArray<string> { JsonCrafterConstants.Hal.MediaTypeHeaderValue }; // Defaults to HAL
        }

        public abstract void Configure(IAppendixBuilder builder);
    }
}
