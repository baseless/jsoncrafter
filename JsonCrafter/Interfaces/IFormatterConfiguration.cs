using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace JsonCrafter.Interfaces
{
    public interface IFormatterConfiguration
    {
        IImmutableDictionary<Type, KeyValuePair<string, string>> Configuration { get; }
    }
}
