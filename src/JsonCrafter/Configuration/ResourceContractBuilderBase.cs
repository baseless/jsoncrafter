﻿using System;
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

        public IResourceConfiguration<TResource> For<TResource>(string url, params Func<TResource, string>[] values) where TResource : class
        {
            var type = typeof(TResource);
            if (Builders.TryGetValue(type, out var typeBuilder) && typeBuilder != default(IResourceBuilder) && typeBuilder is IResourceConfiguration<TResource> castBuilder)
            {
                throw new JsonCrafterException($"Template for '{type.FullName}' has already been configured. Ensure you only call 'For<{type.Name}>()' once in your configuration.");
            }
            
            var newBuilder = new ResourceBuilder<TResource>(url, values.ToArray());
            Builders[type] = newBuilder;
            return newBuilder;
        }
    }
}
