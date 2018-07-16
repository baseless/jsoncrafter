using System;
using JsonCrafter.Shared.Enums;

namespace JsonCrafter.Serialization.Build
{
    public interface IResourceSetting
    {
        ResourceSettingsType SettingsType { get; }
        Type MemberType { get; }
    }
}
