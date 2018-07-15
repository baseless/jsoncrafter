using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using JsonCrafter.Configuration.Interfaces;
using JsonCrafter.Helpers;
using JsonCrafter.Settings;

namespace JsonCrafter.Configuration
{
    public class ResourceBuilder<TResource> : IResourceConfiguration<TResource>, IResourceBuilder where TResource : class
    {
        public ICollection<IResourceEntry> Items { get; } = new HashSet<IResourceEntry>();

        public ResourceBuilder()
        {
            
        }

        public ResourceBuilder(string url, params Expression<Func<TResource, object>>[] values)
        {
            PathHelper.EnsurePathIsValid<TResource>(url);
            Items.Add(new ResourceEntry<TResource>(null, ResourceEntryType.LinkToSelf, url, values));
        }

        public IResourceConfiguration<TResource> ContainsResource(Expression<Func<TResource, object>> resource)
        {
            Items.Add(new ResourceEntry<TResource>(
                resource.Body.Type,
                TypeHelper.IsCollection(resource.Body.Type) ? ResourceEntryType.OneToManyRelation : ResourceEntryType.OneToOneRelation,
                null, 
                null
            ));

            return this;
        }
    }
}
