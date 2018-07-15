using JsonCrafter.Serialization.Interfaces;
using Newtonsoft.Json.Linq;

namespace JsonCrafter.Configuration.Interfaces
{
    public interface IResourceTemplate
    {
        JObject NewResource(IResourceMember member, IResourceContract contract);
        JObject NewRoot(object obj);
        JObject NewObject(object obj);
    }
}
