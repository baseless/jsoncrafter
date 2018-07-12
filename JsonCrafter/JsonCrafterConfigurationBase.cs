using System.Collections.Generic;
using System.Collections.Immutable;
using JsonCrafter.Conversion;
using JsonCrafter.Rules;

namespace JsonCrafter
{
    public abstract class JsonCrafterConfigurationBase : IFormatterConfiguration
    {
        public ImmutableArray<string> SupportedMediaTypes { get; }

        protected JsonCrafterConfigurationBase(IEnumerable<string> supportedMediaTypes = default(IEnumerable<string>))
        {
            SupportedMediaTypes = supportedMediaTypes?.ToImmutableArray() ?? new ImmutableArray<string> { JsonCrafterConstants.Hal.MediaTypeHeaderValue }; // Defaults to HAL
        }

        public abstract void Configure(IRuleBuilder builder);
    }
}
