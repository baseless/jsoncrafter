using System;
using JsonCrafter.Shared.Enums;

namespace JsonCrafter.Build
{
    public interface IResourceMemberEntry
    {
        ResourceEntryType EntryType { get; }
        Type MemberType { get; }
    }
}
