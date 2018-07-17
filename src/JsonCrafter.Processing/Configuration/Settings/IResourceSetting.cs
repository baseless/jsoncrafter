using System;
using JsonCrafter.Core.Enums;

namespace JsonCrafter.Processing.Configuration.Settings
{
    public interface IResourceSetting
    {
        ResourceSettingsType SettingsType { get; }
        Type MemberType { get; }
    }
}
