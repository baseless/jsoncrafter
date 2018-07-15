using System;
using JsonCrafter.Settings;

namespace JsonCrafter.Configuration.Interfaces
{
    public interface IJsonCrafterConfigurationBuilder
    {
        void EnableMediaType(JsonCrafterMediaType type);
        IResourceConfiguration<TResource> For<TResource>(string url, params Func<TResource, string>[] values) where TResource : class;
    }
}
