using System;
using System.Collections.Generic;

namespace JsonCrafter.Build
{
    public interface IResourceBuilder
    {
        IDictionary<Type, ICollection<IResourceSetting>> Settings { get; }
    }
}
