using System;
using System.Collections.Generic;

namespace JsonCrafter.Configuration.Interfaces
{
    public interface ITemplateBuilder : IConfigurationBuilder
    {
        ITypeTemplate BuildeDefaultTemplate();
        IDictionary<Type, ITypeTemplate> BuildTypeTemplates();
    }
}
