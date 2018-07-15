using System;
using System.Collections.Generic;
using JsonCrafter.Core.Configuration.Interfaces;

namespace JsonCrafter.Core.Configuration
{
    public abstract class TemplateBuilderBase
    {
        protected IDictionary<Type, ITypeTemplateBuilder> Builders { get; } = new Dictionary<Type, ITypeTemplateBuilder>();
        protected ICollection<MediaType> EnabledMediaTypes { get; } = new HashSet<MediaType>();

        public void EnableMediaType(MediaType type)
        {
            EnabledMediaTypes.Add(type);
        }
    }
}
