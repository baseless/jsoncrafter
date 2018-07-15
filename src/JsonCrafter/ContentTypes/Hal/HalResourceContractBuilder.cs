using System;
using System.Collections.Generic;
using System.Linq;
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
            return new ResourceContractResolver(new Dictionary<Type, IResourceTemplate>(), new HalResourceTemplate()); // todo: implement
        }
    }
}
