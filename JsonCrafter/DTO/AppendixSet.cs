using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace JsonCrafter.DTO
{
    public class AppendixSet
    {
        public JObject Template { get; }
        public IImmutableList<string> ParameterNames { get; }

        public AppendixSet(JObject template, IOrderedEnumerable<string> parameterNames)
        {
            Template = template ?? throw new ArgumentNullException(nameof(template));
            ParameterNames = parameterNames?.ToImmutableArray() ?? throw new ArgumentNullException(nameof(parameterNames));
        }
    }
}
