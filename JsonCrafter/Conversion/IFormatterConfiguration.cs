using System.Collections.Immutable;
using JsonCrafter.Rules;

namespace JsonCrafter.Conversion
{
    public interface IFormatterConfiguration
    {
        ImmutableArray<string> SupportedMediaTypes { get; }

        void Configure(IJsonRuleBuilder builder);
    }
}
