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
            throw new NotImplementedException();
        }
        
        public ITypeBuilder<T> For<T>() where T : class
        {
            throw new System.NotImplementedException();
        }
    }
}
