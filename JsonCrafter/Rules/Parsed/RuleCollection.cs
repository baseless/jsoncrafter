using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace JsonCrafter.Rules.Parsed
{
    public class RuleCollection : IRuleCollection
    {
        private readonly IImmutableDictionary<Type, IRuleSet> _rules;

        public RuleCollection()
        {
            _rules = new Dictionary<Type, IRuleSet>().ToImmutableDictionary();
        }

        public IRuleSet GetRulesForType(Type type)
        {
            if (type == default(Type))
            {
                return new RuleSet();
            }
            
            return _rules.SingleOrDefault(s => s.Key == type).Value ?? new RuleSet();
        }
    }
}
