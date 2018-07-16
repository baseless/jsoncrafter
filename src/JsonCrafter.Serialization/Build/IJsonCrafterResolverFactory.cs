using JsonCrafter.Serialization.Contracts;

namespace JsonCrafter.Serialization.Build
{
    public interface IJsonCrafterResolverFactory
    {
        IResourceContractResolver Create();
    }
}
