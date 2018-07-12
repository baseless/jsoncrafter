using System;
using System.Collections.Generic;
using JsonCrafter.Templates;

namespace JsonCrafter.Appendices
{
    public sealed class AppendixBuilder : IAppendixBuilder
    {
        private readonly IDictionary<Type, IRuleSetTemplate> _rules;

        public AppendixBuilder()
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
