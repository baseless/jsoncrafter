using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using JsonCrafter.Build;
using JsonCrafter.Shared.Enums;
using Microsoft.AspNetCore.Mvc;

namespace JsonCrafter.Configuration
{
    public class JsonCrafterConfiguratorBase : IJsonCrafterConfigurator
    {
        public ICollection<JsonCrafterMediaType> EnabledMediaTypes { get; } = new List<JsonCrafterMediaType>();

        public void EnableMediaType(JsonCrafterMediaType type)
        {
            EnabledMediaTypes.Add(type);
        }

        public IResourceConfigurator<TResource> For<TResource>(Expression<Func<IUrlHelper, string>> url, params Expression<Func<TResource, object>>[] values) where TResource : class
        {
            return null;
        }
    }
}
