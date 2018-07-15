using System;
using System.Collections.Generic;
using System.Linq;
using JsonCrafter.Configuration.Interfaces;
using JsonCrafter.Settings;

namespace JsonCrafter.Configuration
{
    public abstract class ResourceContractBuilderBase : IResourceContractBuilder, IJsonCrafterBuilder
    {
        protected IDictionary<Type, IResourceBuilder> Builders { get; } = new Dictionary<Type, IResourceBuilder>();
        protected ICollection<JsonCrafterMediaType> EnabledMediaTypes { get; } = new HashSet<JsonCrafterMediaType>();
        protected readonly IJsonCrafterBuilderAction BuilderAction;

        protected ResourceContractBuilderBase(IJsonCrafterBuilderAction builderAction)
        {
            BuilderAction = builderAction ?? throw new ArgumentException(nameof(builderAction));
        }

        public void EnableMediaType(JsonCrafterMediaType type)
        {
            EnabledMediaTypes.Add(type);
        }

        public IResourceConfiguration<TResource> For<TResource>() where TResource : class // todo: Should resource without link to self be allowed? ever? based on mediatype?
        {
            var type = typeof(TResource);
            EnsureResourceHasNotBeenAdded<TResource>(type);

            var newBuilder = new ResourceBuilder<TResource>();
            Builders[type] = newBuilder;
            return newBuilder;
        }

        public IResourceConfiguration<TResource> For<TResource>(string url, params Func<TResource, string>[] values) where TResource : class
        {
            var type = typeof(TResource);
            EnsureResourceHasNotBeenAdded<TResource>(type);
            
            var newBuilder = new ResourceBuilder<TResource>(url, values.ToArray());
            Builders[type] = newBuilder;
            return newBuilder;
        }

        private void EnsureResourceHasNotBeenAdded<TResource>(Type type) where TResource : class
        {
            if (Builders.TryGetValue(type, out var typeBuilder) && typeBuilder is IResourceConfiguration<TResource>)
            {
                throw new JsonCrafterException($"Template for '{type.FullName}' has already been configured. Ensure you only call 'For<{type.Name}>()' once in your configuration.");
            }
        }
    }
}
