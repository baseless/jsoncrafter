using System;
using System.Collections.Generic;
using JsonCrafter.Configuration;
using JsonCrafter.Configuration.Interfaces;
using JsonCrafter.ContentTypes.Hal.Interfaces;
using JsonCrafter.Conversion;
using JsonCrafter.Conversion.Interfaces;

namespace JsonCrafter.ContentTypes.Hal
{
    public class HalResourceContractBuilder : ResourceContractBuilderBase, IHalResourceContractBuilder
    {
        public HalResourceContractBuilder(IJsonCrafterBuilderAction builderAction) : base(builderAction)
        {
            
        }

        public IResourceContractResolver Build()
        {
            BuilderAction.Invoke(this);

            var defaultTemplate = new HalResourceTemplate();
            var constructedTemplates = new Dictionary<Type, IResourceTemplate>();

            // todo: create templates

            return new ResourceContractResolver(constructedTemplates, defaultTemplate);
        }
    }
}
