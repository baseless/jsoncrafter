using JsonCrafterOld.Appendices.Templates;

namespace JsonCrafterOld.Conversion.Shared
{
    public interface IHyperMediaBuilder
    {
        IRuleSetTemplate<T> For<T>() where T : class, new();
    }
}
