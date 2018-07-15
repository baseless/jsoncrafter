using System;
using System.Collections.Generic;
using System.Linq;
using JsonCrafter.Configuration;
using JsonCrafter.Configuration.Interfaces;

namespace JsonCrafter.MediaTypes.Hal
{
    public class HalTemplateBuilder : TemplateBuilderBase, ITemplateBuilder
    {
        public ITypeTemplate BuildeDefaultTemplate()
        {
            return new TypeTemplate();
        }

        public IDictionary<Type, ITypeTemplate> BuildTypeTemplates()
        {
            return new Dictionary<Type, ITypeTemplate>();
        }
        
        public ITypeBuilder<TResource> For<TResource>(string url, params Func<TResource, string>[] values) where TResource : class
        {
            var type = typeof(TResource);
            if (Builders.TryGetValue(type, out var typeBuilder) && typeBuilder != default(ITypeTemplateBuilder) && typeBuilder is ITypeBuilder<TResource> castBuilder)
            {
                    throw new JsonCrafterException($"Template for '{type.FullName}' has already been configured. Ensure you only call 'For<{type.Namespace}>()' once in your configuration.");
            }

            if (!Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out var uri))
            {
                throw new JsonCrafterException($"Template could not be created for type '{type.FullName}' (reason: '{url}' is not a valid url).");
            }
            
            var newBuilder = new TypeBuilder<TResource>(uri, values.ToArray());
            Builders[type] = newBuilder;
            return newBuilder;
        }

        public class TypeBuilder<TResource> : ITypeBuilder<TResource>, ITypeTemplateBuilder where TResource : class
        {
            public TypeBuilder(Uri uri, params Func<TResource, string>[] values)
            {
                
            }

            //public ITypeBuilder<T> HasTemplate(string url, string templateIdentifier)
            //{
            //    return this;
            //}

            //public ITypeBuilder<T> HasRelatedResource(Func<T, object> resource)
            //{
            //    return this;
            //}

            //public ITypeBuilder<T> HasLinkToSelf(string url, params string[] values)
            //{
            //    return this;
            //}

            //public ITypeBuilder<T> HasLinkToSelf(string url, params Func<T, object>[] values)
            //{
            //    return this;
            //}

            //public ITypeBuilder<T> HasLink(string name, string templateId, string url, params Func<T, object>[] values)
            //{
            //    return this;
            //}

            //public ITypeBuilder<T> HasLink(string name, string templateId, string url, params string[] values)
            //{
            //    return this;
            //}
        }
    }
}
