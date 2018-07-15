using System;
using System.Linq.Expressions;
using JsonCrafter.Settings;

namespace JsonCrafter.Configuration.Interfaces
{
    public interface IJsonCrafterBuilder
    {
        void EnableMediaType(JsonCrafterMediaType type);
        IResourceConfiguration<TResource> For<TResource>(string url, params Expression<Func<TResource, object>>[] values) where TResource : class;
    }
}
