using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using JsonCrafter.Interfaces;

namespace JsonCrafter.Demo.Api.Configuration
{
    public class JsonFormatterConfiguration : IFormatterConfiguration
    {
        public IImmutableDictionary<Type, KeyValuePair<string, string>> Configuration => new Dictionary<Type, KeyValuePair<string, string>>().ToImmutableDictionary();
    }
}
