using JsonCrafter.Serialization.Contracts;
using JsonCrafter.Serialization.Contracts.Members;
using Newtonsoft.Json.Linq;

namespace JsonCrafter.Build
{
    public interface IResourceTemplate
    {
        JObject NewResource(IResourceMember member, IResourceContract contract);
        JObject NewRoot(object obj);
        JObject NewObject(object obj);
    }
}
