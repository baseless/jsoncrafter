using System;
using JsonCrafter.Core.Enums;

namespace JsonCrafter.Processing.Configuration.Settings
{
    public interface IResourceSettingConfiguration
    {
        ResourceSettingsType SettingsType { get; }
    }
}
