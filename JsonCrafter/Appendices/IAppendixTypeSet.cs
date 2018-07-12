using System.Collections.Immutable;
using JsonCrafter.DTO;

namespace JsonCrafter.Appendices
{
    public interface IAppendixTypeSet
    {
        IImmutableList<Appendix> Appendices { get; }
    }
}
