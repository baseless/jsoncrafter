using System;
using JsonCrafter.Settings;

namespace JsonCrafter.Configuration.Interfaces
{
    public interface IResourceMemberEntry
    {
        ResourceEntryType EntryType { get; }
        Type MemberType { get; }
    }
}
