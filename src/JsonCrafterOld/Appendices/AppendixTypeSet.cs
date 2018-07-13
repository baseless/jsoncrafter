using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using JsonCrafterOld.DTO;
using Newtonsoft.Json.Linq;

namespace JsonCrafterOld.Appendices
{
    public sealed class AppendixTypeSet : IAppendixTypeSet
    {
        public IImmutableList<Appendix> Appendices { get; }

        public AppendixTypeSet()
        {
            Appendices = new ImmutableArray<Appendix>();
        }

        public AppendixTypeSet(IEnumerable<Appendix> sets)
        {
            if (sets == null)
            {
                throw new ArgumentNullException(nameof(sets));
            }

            Appendices = sets.ToImmutableArray();
        }

        public AppendixTypeSet(JObject template, IOrderedEnumerable<string> parameterNames)
        {
            Appendices = new ImmutableArray<Appendix>
            {
                new Appendix(template, parameterNames)
            };
        }
    }
}
