using System;
using System.Collections.Generic;

namespace JsonCrafter.Serialization.Build
{
    public interface IResourceBuilder
    {
        IDictionary<Type, ICollection<IResourceSetting>> Settings { get; }
    }
}
