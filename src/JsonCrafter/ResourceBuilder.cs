using System;
using JsonCrafter.Configuration.Interfaces;

namespace JsonCrafter
{
    public class ResourceBuilder<TResource> : IResourceConfiguration<TResource>, IResourceBuilder where TResource : class
    {
        public ResourceBuilder(Uri uri, params Func<TResource, string>[] values)
        {

        }
    }
}
