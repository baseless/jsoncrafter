using System;
using System.Collections.Generic;
using JsonCrafter.Configuration.Interfaces;
using JsonCrafter.Settings;

namespace JsonCrafter.Configuration
{
    public abstract class ResourceContractBuilderBase
    {
        protected IDictionary<Type, IResourceBuilder> Builders { get; } = new Dictionary<Type, IResourceBuilder>();
        protected ICollection<JsonCrafterMediaType> EnabledMediaTypes { get; } = new HashSet<JsonCrafterMediaType>();

        public void EnableMediaType(JsonCrafterMediaType type)
        {
            EnabledMediaTypes.Add(type);
        }
    }
}
