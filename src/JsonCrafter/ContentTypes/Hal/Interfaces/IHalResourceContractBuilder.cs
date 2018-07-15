using JsonCrafter.Configuration.Interfaces;
using JsonCrafter.Conversion.Interfaces;

namespace JsonCrafter.ContentTypes.Hal.Interfaces
{
    public interface IHalResourceContractBuilder : IResourceContractBuilder
    {
        IResourceContractResolver Build();
    }
}
