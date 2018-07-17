using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using JsonCrafter.Core.Enums;
using JsonCrafter.Core.Exceptions;
using JsonCrafter.Processing.Configuration;
using JsonCrafter.Processing.Configuration.Settings;

namespace JsonCrafter.Processing.Compilation
{
    public class ConfigurationBuilderBase : IConfigurationBuilder
    {
        public ICollection<JsonCrafterMediaType> EnabledMediaTypes { get; } = new List<JsonCrafterMediaType>();
        private readonly IDictionary<Type, IResourceConfiguration> _resources = new Dictionary<Type, IResourceConfiguration>();

        private JsonCrafterCasing _casingFormat = JsonCrafterCasing.CamelCase;

        public JsonCrafterCasing GetCasing() => _casingFormat;

        public void SetCasing(JsonCrafterCasing format)
        {
            _casingFormat = format;
        }

        public void EnableMediaType(JsonCrafterMediaType type)
        {
            EnabledMediaTypes.Add(type);
        }

        public IResourceBuilder<TResource> For<TResource>() where TResource : class
        {
            EnsureResourceNotAlreadyAdded(typeof(TResource));

            var resource = new ConfigurationBuilder<TResource>(this);
            _resources.Add(typeof(TResource), resource);
            return resource;
        }

        public IResourceBuilder<TResource> For<TResource>(string urlToSelf, params Expression<Func<TResource, Type>>[] urlParameters) where TResource : class
        {
            EnsureResourceNotAlreadyAdded(typeof(TResource));

            var setting = new LinkSettings<TResource>(typeof(TResource), LinkSettingsType.ToSelf, null, urlToSelf, urlParameters);
            var resource = new ConfigurationBuilder<TResource>(this, setting);
            _resources.Add(typeof(TResource), resource);
            return resource;
        }

        private void EnsureResourceNotAlreadyAdded(Type type)
        {
            if (_resources.ContainsKey(type))
            {
                throw new JsonCrafterException($"Configuration for '{type.FullName}' can not be initialized more than once. Ensure that only one 'For<{type.Name}>()' call occurs in your configuration.");
            }
        }
    }
}
