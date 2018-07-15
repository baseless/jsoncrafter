using System;
using System.Collections.Generic;
using System.Linq;
using JsonCrafter.Configuration;
using JsonCrafter.Configuration.Interfaces;
using JsonCrafter.ContentTypes.Hal.Interfaces;
using JsonCrafter.Conversion.Hal;
using JsonCrafter.Conversion.Interfaces;

namespace JsonCrafter.ContentTypes.Hal
{
    public class HalResourceContractBuilder : ResourceContractBuilderBase, IHalResourceContractBuilder
    {
        private readonly IJsonCrafterBuilderAction _builderAction;

        public HalResourceContractBuilder(IJsonCrafterBuilderAction builderAction)
        {
            _builderAction = builderAction ?? throw new ArgumentException(nameof(builderAction));
        }

        public IResourceContractResolver Build()
        {
            return new ResourceContractResolver(new Dictionary<Type, IResourceTemplate>(), new HalResourceTemplate()); // todo: implement
        }
        
        public IResourceConfiguration<TResource> For<TResource>(string url, params Func<TResource, string>[] values) where TResource : class
        {
            var type = typeof(TResource);
            if (Builders.TryGetValue(type, out var typeBuilder) && typeBuilder != default(IResourceBuilder) && typeBuilder is IResourceConfiguration<TResource> castBuilder)
            {
                    throw new JsonCrafterException($"Template for '{type.FullName}' has already been configured. Ensure you only call 'For<{type.Namespace}>()' once in your configuration.");
            }

            if (!Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out var uri))
            {
                throw new JsonCrafterException($"Template could not be created for type '{type.FullName}' (reason: '{url}' is not a valid url).");
            }
            
            var newBuilder = new HalResourceBuilder<TResource>(uri, values.ToArray());
            Builders[type] = newBuilder;
            return newBuilder;
        }

        public class HalResourceBuilder<TResource> : IResourceConfiguration<TResource>, IResourceBuilder where TResource : class
        {
            public HalResourceBuilder(Uri uri, params Func<TResource, string>[] values)
            {
                
            }
        }
    }
}
