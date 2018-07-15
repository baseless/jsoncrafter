using JsonCrafter.Shared.Enums;

namespace JsonCrafter.Configuration
{
    public interface IJsonCrafterConfigurator
    {
        void EnableMediaType(JsonCrafterMediaType type);
        //IResourceConfiguration<TResource> For<TResource>(string url, params Expression<Func<TResource, object>>[] values) where TResource : class;
    }
}
