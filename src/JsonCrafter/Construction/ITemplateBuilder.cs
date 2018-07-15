using System;
using System.Collections.Generic;
using JsonCrafter.Configuration.Interfaces;

namespace JsonCrafter.Construction
{
    public interface ITemplateBuilder : IConfigurationBuilder
    {
        ITypeTemplate BuildeDefaultTemplate();
        IDictionary<Type, ITypeTemplate> BuildTypeTemplates();
    }
}
