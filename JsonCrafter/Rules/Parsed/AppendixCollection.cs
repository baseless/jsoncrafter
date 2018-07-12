using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace JsonCrafter.Rules.Parsed
{
    public class AppendixCollection : IAppendixCollection
    {
        private readonly IImmutableDictionary<Type, IAppendix> _rules;

        public AppendixCollection()
        {
            _rules = new Dictionary<Type, IAppendix>().ToImmutableDictionary();
        }

        public IAppendix ForType(Type type)
        {
            return type == default(Type) ? null : _rules.SingleOrDefault(s => s.Key == type).Value;
        }
    }
}
