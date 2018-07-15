using JsonCrafter.Configuration.Interfaces;
using JsonCrafter.Serialization.Interfaces;

namespace JsonCrafter.Configuration.Hal.Interfaces
{
    public interface IHalResourceContractBuilder : IResourceContractBuilder
    {
        IResourceContractResolver Build();
    }
}
