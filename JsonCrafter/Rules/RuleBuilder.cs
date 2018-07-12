using System;
using System.Collections.Generic;
using JsonCrafter.Rules.Parsed;
using JsonCrafter.Rules.Templates;

namespace JsonCrafter.Rules
{
    public class RuleBuilder : IRuleBuilder
    {
        private readonly IDictionary<Type, IRuleSetTemplate> _rules;

        public RuleBuilder()
        {
            _rules = new Dictionary<Type, IRuleSetTemplate>();
        }

        public IAppendixCollection Build()
        {
            return new AppendixCollection();
        }

        public IRuleSetTemplate<T> For<T>() where T : class, new()
        {
            var rule = new RuleSetTemplate<T>();
            _rules.Add(typeof(T), rule);

            return rule;
        }
    }
}
