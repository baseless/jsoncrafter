using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using JsonCrafter.Serialization.Build;
using JsonCrafter.Shared.Enums;
using JsonCrafter.Shared.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace JsonCrafter.Serialization.Configuration
{
    public class JsonCrafterConfiguratorBase : IJsonCrafterConfigurator
    {
        public ICollection<JsonCrafterMediaType> EnabledMediaTypes { get; } = new List<JsonCrafterMediaType>();
        private IDictionary<Type, IResourceBuilder> _resources = new Dictionary<Type, IResourceBuilder>();


        public void EnableMediaType(JsonCrafterMediaType type)
        {
            EnabledMediaTypes.Add(type);
        }

        public IResourceConfigurator<TResource> For<TResource>(Expression<Func<IUrlHelper, string>> url, params Expression<Func<TResource, object>>[] values) where TResource : class
        {
            if (_resources.ContainsKey(typeof(TResource)))
            {
                throw new JsonCrafterException($"Configuration for '{typeof(TResource).FullName}' can not be initialized more than once. Ensure that only one 'For<{typeof(TResource).Name}>()' call occurs in your configuration.");
            }

            var setting = new LinkSetting<TResource>(typeof(TResource), LinkSettingsType.ToSelf, null, url, values);
            var resource = new ResourceConfigurator<TResource>(this, setting);
            _resources.Add(typeof(TResource), resource);
            return resource;
        }
    }
}
