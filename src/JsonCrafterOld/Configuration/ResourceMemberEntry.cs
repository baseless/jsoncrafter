using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using JsonCrafterOld.Configuration.Interfaces;
using JsonCrafterOld.Settings;

namespace JsonCrafterOld.Configuration // todo: IMPLEMENT: Option to flag property to not be mapped if jsonignore
{
    public class ResourceMemberEntry<TResource> : IResourceMemberEntry
    {
        public ResourceMemberEntry(Type memberType, ResourceEntryType entryType, string url, ICollection<Expression<Func<TResource, object>>> values)
        {
            EntryType = entryType;
            MemberType = memberType ?? typeof(TResource);
            _entryValues = values ?? new Expression<Func<TResource, object>>[0];
            Url = url ?? string.Empty;
        }

        public ResourceEntryType EntryType { get; }
        public Type MemberType { get; }
        private ICollection<Expression<Func<TResource, object>>> _entryValues;
        public string Url { get; }
    }
}
