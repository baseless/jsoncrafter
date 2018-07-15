using JsonCrafter.Conversion.Interfaces;

namespace JsonCrafter.Configuration.Interfaces
{
    public interface IResourceContractBuilder
    {
        IResourceContractResolver Build();
    }
}
