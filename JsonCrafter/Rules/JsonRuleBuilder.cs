using System;
using System.Collections;
using System.Collections.Generic;
using JsonCrafter.DTO;

namespace JsonCrafter.Rules
{
    public class JsonRuleBuilder : IJsonRuleBuilder
    {
        private readonly IDictionary<Type, IJsonTypeRule> _rules;

        public JsonRuleBuilder()
        {
            _rules = new Dictionary<Type, IJsonTypeRule>();
        }

        public IJsonRuleSet Build()
        {
            return new JsonCrafterRuleSet();
        }

        public IJsonTypeRule<T> For<T>() where T : class, new()
        {
            var rule = new JsonTypeRule<T>();
            _rules.Add(typeof(T), rule);

            return rule;
        }
    }
}
