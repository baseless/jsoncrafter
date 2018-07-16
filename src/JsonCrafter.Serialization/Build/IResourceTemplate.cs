using JsonCrafter.Serialization.Contracts;
using JsonCrafter.Serialization.Contracts.Members;
using Newtonsoft.Json.Linq;

namespace JsonCrafter.Serialization.Build
{
    public interface IResourceTemplate
    {
        JObject NewResource(IContractMember member, IResourceContract contract);
        JObject NewRoot(object obj);
        JObject NewObject(object obj);
    }
}
