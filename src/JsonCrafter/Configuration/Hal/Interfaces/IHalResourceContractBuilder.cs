using JsonCrafter.Configuration.Interfaces;
using JsonCrafter.Conversion.Interfaces;

namespace JsonCrafter.Configuration.Hal.Interfaces
{
    public interface IHalResourceContractBuilder : IResourceContractBuilder
    {
        IResourceContractResolver Build();
    }
}
