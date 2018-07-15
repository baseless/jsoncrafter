using JsonCrafter.Configuration.Interfaces;
using JsonCrafter.Serialization.Contracts;
using Newtonsoft.Json.Linq;

namespace JsonCrafter.Construction
{
    public class TypeTemplate : ITypeTemplate
    {
        public JObject GetResourceBase(IMember member, IContract contract)
        {
            return new JObject();
        }

        public JObject GetRoot(object obj)
        {
            return new JObject();
        }

        public JObject GetObject(object obj)
        {
            return new JObject();
        }
    }
}
