using JsonCrafter.Serialization.Contracts;
using Newtonsoft.Json.Linq;

namespace JsonCrafter.Configuration.Interfaces
{
    public interface ITypeTemplate
    {
        JObject GetResourceBase(IMember member, IContract contract);
        JObject GetRoot(object obj);
        JObject GetObject(object obj);
    }
}
