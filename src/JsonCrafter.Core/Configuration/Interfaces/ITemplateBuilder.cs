using System;
using System.Collections.Generic;

namespace JsonCrafter.Core.Configuration.Interfaces
{
    public interface ITemplateBuilder : IConfigurationBuilder
    {
        ITypeTemplate BuildeDefaultTemplate();
        IDictionary<Type, ITypeTemplate> BuildTypeTemplates();
    }
}
