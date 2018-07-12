using JsonCrafter.Rules.Parsed;
using JsonCrafter.Rules.Templates;

namespace JsonCrafter.Rules
{
    public interface IRuleBuilder
    {
        IRuleCollection Build();
        IRuleSetTemplate<T> For<T>() where T : class, new();
    }
}
