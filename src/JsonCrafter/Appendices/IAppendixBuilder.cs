using JsonCrafter.Appendices.Templates;

namespace JsonCrafter.Appendices
{
    public interface IAppendixBuilder
    {
        IAppendixCollection Build();
        IRuleSetTemplate<T> For<T>() where T : class, new();
    }
}
