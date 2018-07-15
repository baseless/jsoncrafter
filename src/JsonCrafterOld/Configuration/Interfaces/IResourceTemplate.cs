using JsonCrafterOld.Serialization.Interfaces;
using Newtonsoft.Json.Linq;

namespace JsonCrafterOld.Configuration.Interfaces
{
    public interface IResourceTemplate
    {
        JObject NewResource(IResourceMember member, IResourceContract contract);
        JObject NewRoot(object obj);
        JObject NewObject(object obj);
    }
}
