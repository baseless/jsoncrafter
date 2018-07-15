using JsonCrafterOld.Configuration.Interfaces;
using JsonCrafterOld.Serialization.Interfaces;

namespace JsonCrafterOld.Configuration.Hal.Interfaces
{
    public interface IHalResourceContractBuilder : IResourceContractBuilder
    {
        IResourceContractResolver Build();
    }
}
