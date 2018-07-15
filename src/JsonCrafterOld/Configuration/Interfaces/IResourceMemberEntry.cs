using System;
using JsonCrafterOld.Settings;

namespace JsonCrafterOld.Configuration.Interfaces
{
    public interface IResourceMemberEntry
    {
        ResourceEntryType EntryType { get; }
        Type MemberType { get; }
    }
}
