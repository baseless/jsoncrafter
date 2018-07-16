
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using JsonCrafter.Configuration;
using JsonCrafter.Shared.Enums;

namespace JsonCrafter.Build
{
    public class JsonCrafterConfigurationFetcher : IJsonCrafterConfigurator
    {
        public ICollection<JsonCrafterMediaType> EnabledMediaTypes { get; } = new List<JsonCrafterMediaType>();

        public void EnableMediaType(JsonCrafterMediaType type)
        {
            EnabledMediaTypes.Add(type);
        }

        public IResourceConfigurator<TResource> For<TResource>(string url, params Expression<Func<TResource, object>>[] values) where TResource : class
        {
            return null;
        }
    }
}
