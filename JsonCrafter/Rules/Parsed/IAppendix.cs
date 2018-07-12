using System.Collections.Immutable;
using JsonCrafter.DTO;
using Newtonsoft.Json.Linq;

namespace JsonCrafter.Rules.Parsed
{
    public interface IAppendix
    {
        IImmutableList<AppendixSet> Sets { get; }
    }
}
