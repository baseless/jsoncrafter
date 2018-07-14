using JsonCrafter.Core.Contracts;
using Newtonsoft.Json.Linq;

namespace JsonCrafter.Conversion.Shared
{
    public interface ITemplateBuilder
    {
        JObject BuildRoot(object obj, ITypeContract contract);
        JObject BuildObject(object obj, ITypeContract contract);
        JObject BuildResource(IMemberContract member, ITypeContract contract);
    }
}
