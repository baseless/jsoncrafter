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
        
        public ITypeBuilder<T> For<T>() where T : class
        {
            return new TypeBuilder<T>();
        }

        public class TypeBuilder<T> : ITypeBuilder<T> where T : class
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
