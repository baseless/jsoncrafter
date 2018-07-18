using System;
using System.Collections.Generic;
using JsonCrafter.Core.Enums;
using JsonCrafter.Core.Exceptions;

namespace JsonCrafter.Processing.Configuration
{
    public class ConfigurationBuilderBase : IConfigurationBuilder
    {
        public ICollection<JsonCrafterMediaType> EnabledMediaTypes { get; } = new List<JsonCrafterMediaType>();
        public IDictionary<Type, IResource> Resources { get; }  = new Dictionary<Type, IResource>();

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
            var resource = new ResourceBuilder<TResource>(this);
            Resources.Add(typeof(TResource), resource);
            return resource;
        }

        private void EnsureResourceNotAlreadyAdded(Type type)
        {
            if (Resources.ContainsKey(type))
            {
                throw new JsonCrafterException($"Configuration for '{type.FullName}' can not be initialized more than once. Ensure that only one 'For<{type.Name}>()' call occurs in your configuration.");
            }
        }
    }
}
