using System.Collections.Immutable;
using JsonCrafter.Appendices;

namespace JsonCrafter.Formatting
{
    public interface IFormatterConfiguration
    {
        ImmutableArray<string> SupportedMediaTypes { get; }

        void Configure(IAppendixBuilder builder);
    }
}
