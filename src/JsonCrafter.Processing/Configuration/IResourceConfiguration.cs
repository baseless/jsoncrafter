using System;
using System.Collections.Generic;
using JsonCrafter.Processing.Configuration.Settings;

namespace JsonCrafter.Processing.Configuration
{
    public interface IResourceConfiguration
    {
        IDictionary<Type, ICollection<IResourceSettingConfiguration>> Settings { get; }
    }
}
