using System;
using System.Collections.Generic;
using JsonCrafterOld.Appendices.Templates;
using JsonCrafterOld.Conversion.Shared;

namespace JsonCrafterOld.Appendices
{
    public abstract class AppendixBuilder<TConverter> : IHyperMediaBuilder where TConverter: HyperMediaOutputConverter<TConverter>
    {
        protected readonly IDictionary<Type, IRuleSetTemplate> Rules;

        protected AppendixBuilder()
        {
            Rules = new Dictionary<Type, IRuleSetTemplate>();
        }

        public abstract IAppendixCollection<TConverter> Build();

        public IRuleSetTemplate<T> For<T>() where T : class, new()
        {
            var rule = new RuleSetTemplate<T>();
            Rules.Add(typeof(T), rule);

            return rule;
        }
    }
}
