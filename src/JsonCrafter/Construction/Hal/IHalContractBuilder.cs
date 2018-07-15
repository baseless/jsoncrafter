using JsonCrafter.Serialization.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace JsonCrafter.Construction.Hal
{
    public interface IHalContractBuilder
    {
        IContractResolver Build(IUrlHelper urlHelper);
    }
}
