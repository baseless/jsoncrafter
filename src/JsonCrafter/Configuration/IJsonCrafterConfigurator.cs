using System;
using System.Linq.Expressions;
using JsonCrafter.Build;
using JsonCrafter.Shared.Enums;

namespace JsonCrafter.Configuration
{
    public interface IJsonCrafterConfigurator
    {
        void EnableMediaType(JsonCrafterMediaType type);
        IResourceConfigurator<TResource> For<TResource>(string url, params Expression<Func<TResource, object>>[] values) where TResource : class;
    }
}
