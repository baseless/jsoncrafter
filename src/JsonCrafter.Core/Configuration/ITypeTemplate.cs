using JsonCrafter.Core.Contracts;
using Newtonsoft.Json.Linq;

namespace JsonCrafter.Core.Configuration
{
    public interface ITypeTemplate
    {
        JObject GetRoot(object obj);
        JObject GetObject(object obj);
        JObject GetResourceObject(IMemberContract member, object obj);
    }
}
