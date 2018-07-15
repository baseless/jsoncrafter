using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using JsonCrafter.Settings;

namespace JsonCrafter.Configuration.Interfaces
{
    public interface IResourceEntry
    {
        ResourceEntryType EntryType { get; }
        Type MemberType { get; }
        string Url { get; }
    }
}
