using System;
using System.Collections.Generic;
using JsonCrafter.Configuration.Interfaces;
using JsonCrafter.Helpers;
using JsonCrafter.Settings;

namespace JsonCrafter.Configuration
{
    public class ResourceBuilder<TResource> : IResourceConfiguration<TResource>, IResourceBuilder where TResource : class
    {
        public readonly ICollection<IResourceAppendix> Appendixes = new HashSet<IResourceAppendix>();

        public ResourceBuilder()
        {
            
        }

        public ResourceBuilder(string url, params Func<TResource, string>[] values)
        {
            PathHelper.EnsurePathIsValid<TResource>(url);
            Appendixes.Add(new ResourceAppendix<TResource>(ResourceAppendixType.LinkToSelf, url, values));
        }
    }
}
