using JsonCrafter.Conversion.Interfaces;
using Newtonsoft.Json.Linq;

namespace JsonCrafter.Configuration.Interfaces
{
    public interface IResourceTemplate
    {
        JObject GetResourceBase(IResourceMember member, IResourceContract contract);
        JObject GetRoot(object obj);
        JObject GetObject(object obj);
    }
}
