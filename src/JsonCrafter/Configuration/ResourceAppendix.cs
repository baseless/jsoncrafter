using System;
using JsonCrafter.Configuration.Interfaces;
using JsonCrafter.Settings;

namespace JsonCrafter.Configuration
{
    public class ResourceAppendix<TResource> : IResourceAppendix
    {
        public ResourceAppendix(ResourceAppendixType appendixType, string url, Func<TResource, string>[] values)
        {
            AppendixType = appendixType;
            _values = values ?? throw new ArgumentNullException(nameof(values));
            _url = url ?? throw new ArgumentNullException(nameof(url));
        }

        public ResourceAppendixType AppendixType { get; }
        private Func<TResource, string>[] _values;
        private string _url;
    }
}
