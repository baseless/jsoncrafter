using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using JsonCrafterOld.Conversion.Shared;

namespace JsonCrafterOld.Appendices
{
    public sealed class AppendixCollection<TConverter> : IAppendixCollection<TConverter> where TConverter: HyperMediaOutputConverter<TConverter>
    {
        private readonly IImmutableDictionary<Type, IAppendixTypeSet> _sets;

        public AppendixCollection()
        {
            _sets = new Dictionary<Type, IAppendixTypeSet>().ToImmutableDictionary();
        }

        public AppendixCollection(IImmutableDictionary<Type, IAppendixTypeSet> sets)
        {
            _sets = sets?.ToImmutableDictionary() ?? throw new ArgumentNullException(nameof(sets));
        }

        public IAppendixTypeSet ForType(Type type)
        {
            return type == default(Type) ? null : _sets.SingleOrDefault(s => s.Key == type).Value;
        }
    }
}
