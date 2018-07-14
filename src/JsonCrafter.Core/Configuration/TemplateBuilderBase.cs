using System.Collections.Generic;

namespace JsonCrafter.Core.Configuration
{
    public abstract class TemplateBuilderBase
    {
        protected ICollection<MediaType> EnabledMediaTypes { get; } = new HashSet<MediaType>();

        public void EnableMediaType(MediaType type)
        {
            EnabledMediaTypes.Add(type);
        }
    }
}
