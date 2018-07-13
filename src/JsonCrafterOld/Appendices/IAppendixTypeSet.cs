using System.Collections.Immutable;
using JsonCrafterOld.DTO;

namespace JsonCrafterOld.Appendices
{
    public interface IAppendixTypeSet
    {
        IImmutableList<Appendix> Appendices { get; }
    }
}
