using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using JsonCrafter.DTO;
using Newtonsoft.Json.Linq;

namespace JsonCrafter.Rules.Parsed
{
    public class Appendix : IAppendix
    {
        public IImmutableList<AppendixSet> Sets { get; }

        public Appendix()
        {
            Sets = new ImmutableArray<AppendixSet>();
        }

        public Appendix(IEnumerable<AppendixSet> sets)
        {
            if (sets == null)
            {
                throw new ArgumentNullException(nameof(sets));
            }

            Sets = sets.ToImmutableArray();
        }

        public Appendix(JObject template, IOrderedEnumerable<string> parameterNames)
        {
            Sets = new ImmutableArray<AppendixSet>
            {
                new AppendixSet(template, parameterNames)
            };
        }
    }
}
