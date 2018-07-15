using JsonCrafter.Configuration.Interfaces;
using JsonCrafter.Contracts.Interfaces;
using Newtonsoft.Json.Linq;

namespace JsonCrafter.Configuration
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
