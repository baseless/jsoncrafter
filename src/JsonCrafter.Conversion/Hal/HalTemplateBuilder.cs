using System;
using System.Collections.Generic;
using JsonCrafter.Core.Configuration;
using JsonCrafter.Core.Configuration.Interfaces;

namespace JsonCrafter.Conversion.Hal
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
        
        public ITypeBuilder<TResource> For<TResource>() where TResource : class
        {
            var type = typeof(TResource);
            if (Builders.TryGetValue(type, out var typeBuilder) && typeBuilder != default(ITypeTemplateBuilder) && typeBuilder is ITypeBuilder<TResource> castBuilder)
            {
                    return castBuilder;
            }

            var newBuilder = new TypeBuilder<TResource>();
            Builders[type] = newBuilder;
            return newBuilder;
        }

        public class TypeBuilder<T> : ITypeBuilder<T>, ITypeTemplateBuilder where T : class
        {
            public ITypeBuilder<T> HasTemplate(string url, string templateIdentifier)
            {
                return this;
            }

            public ITypeBuilder<T> HasRelatedResource(Func<T, object> resource)
            {
                return this;
            }

            public ITypeBuilder<T> HasLinkToSelf(string url, params string[] values)
            {
                return this;
            }

            public ITypeBuilder<T> HasLinkToSelf(string url, params Func<T, object>[] values)
            {
                return this;
            }

            public ITypeBuilder<T> HasLink(string name, string templateId, string url, params Func<T, object>[] values)
            {
                return this;
            }

            public ITypeBuilder<T> HasLink(string name, string templateId, string url, params string[] values)
            {
                return this;
            }
        }
    }
}
