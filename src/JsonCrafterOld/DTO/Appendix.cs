using System;
using System.Collections.Immutable;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace JsonCrafterOld.DTO
{
    public class Appendix
    {
        public JObject Template { get; }
        public IImmutableList<string> ParameterNames { get; }

        public Appendix(JObject template, IOrderedEnumerable<string> parameterNames)
        {
            Template = template ?? throw new ArgumentNullException(nameof(template));
            ParameterNames = parameterNames?.ToImmutableArray() ?? throw new ArgumentNullException(nameof(parameterNames));
        }
    }
}
