using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace JsonCrafter.Appendices
{
    public sealed class AppendixCollection : IAppendixCollection
    {
        private readonly IImmutableDictionary<Type, IAppendixTypeSet> _sets;

        public AppendixCollection()
        {
            _sets = new Dictionary<Type, IAppendixTypeSet>().ToImmutableDictionary();
        }

        public AppendixCollection(IDictionary<Type, IAppendixTypeSet> sets)
        {
            _sets = sets?.ToImmutableDictionary() ?? throw new ArgumentNullException(nameof(sets));
        }

        public IAppendixTypeSet ForType(Type type)
        {
            return type == default(Type) ? null : _sets.SingleOrDefault(s => s.Key == type).Value;
        }
    }
}
