using System;
using System.Linq;
using JsonCrafter.Serialization.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace JsonCrafter.Construction.Hal
{
    public class HalContractBuilder : ContractBuilderBase, IHalContractBuilder
    {
        private readonly Action<IConfigurationBuilder, IUrlHelper> _configBuilder;

        public HalContractBuilder(Action<IConfigurationBuilder, IUrlHelper> configBuilder)
        {
            _configBuilder = configBuilder;
        }

        public IContractResolver Build(IUrlHelper urlHelper)
        {
            _configBuilder.BeginInvoke(this, urlHelper);
            return null;
        }
        
        public ITypeBuilder<TResource> For<TResource>(string url, params Func<TResource, string>[] values) where TResource : class
        {
            var type = typeof(TResource);
            if (Builders.TryGetValue(type, out var typeBuilder) && typeBuilder != default(IContractBuilder) && typeBuilder is ITypeBuilder<TResource> castBuilder)
            {
                    throw new JsonCrafterException($"Template for '{type.FullName}' has already been configured. Ensure you only call 'For<{type.Namespace}>()' once in your configuration.");
            }

            if (!Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out var uri))
            {
                throw new JsonCrafterException($"Template could not be created for type '{type.FullName}' (reason: '{url}' is not a valid url).");
            }
            
            var newBuilder = new HalTypeBuilder<TResource>(uri, values.ToArray());
            Builders[type] = newBuilder;
            return newBuilder;
        }
        
        public class HalTypeBuilder<TResource> : ITypeBuilder<TResource>, IContractBuilder where TResource : class
        {
            public HalTypeBuilder(Uri uri, params Func<TResource, string>[] values)
            {
                
            }
        }
    }
}
