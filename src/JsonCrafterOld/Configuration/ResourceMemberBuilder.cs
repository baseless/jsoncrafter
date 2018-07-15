using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using JsonCrafterOld.Configuration.Interfaces;
using JsonCrafterOld.Helpers;
using JsonCrafterOld.Settings;

namespace JsonCrafterOld.Configuration
{
    public class ResourceMemberBuilder<TResource> : IResourceConfiguration<TResource>, IResourceMemberBuilder where TResource : class
    {
        public ICollection<IResourceMemberEntry> Items { get; } = new HashSet<IResourceMemberEntry>();

        public ResourceMemberBuilder()
        {
            
        }

        public ResourceMemberBuilder(string url, params Expression<Func<TResource, object>>[] values)
        {
            PathHelper.EnsurePathIsValid<TResource>(url);
            Items.Add(new ResourceMemberEntry<TResource>(null, ResourceEntryType.LinkToSelf, url, values));
        }

        public IResourceConfiguration<TResource> ContainsResource(Expression<Func<TResource, object>> resource)
        {
            Items.Add(new ResourceMemberEntry<TResource>(
                resource.Body.Type,
                TypeHelper.IsCollection(resource.Body.Type) ? ResourceEntryType.OneToManyRelation : ResourceEntryType.OneToOneRelation,
                null, 
                null
            ));

            return this;
        }
    }
}
