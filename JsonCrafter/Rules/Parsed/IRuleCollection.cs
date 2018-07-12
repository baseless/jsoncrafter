using System;

namespace JsonCrafter.Rules.Parsed
{
    public interface IRuleCollection
    {
        IRuleSet GetRulesForType(Type type);
    }
}
