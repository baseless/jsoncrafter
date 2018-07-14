using JsonCrafter.Core.Contracts.Interfaces;
using Newtonsoft.Json.Linq;

namespace JsonCrafter.Core.Configuration.Interfaces
{
    public interface ITypeTemplate
    {
        JObject GetResourceBase(IMember member, IContract contract);
        JObject GetRoot(object obj);
        JObject GetObject(object obj);
    }
}
