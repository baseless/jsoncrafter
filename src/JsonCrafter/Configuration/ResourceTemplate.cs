using JsonCrafter.Configuration.Interfaces;
using JsonCrafter.Conversion.Interfaces;
using Newtonsoft.Json.Linq;

namespace JsonCrafter.Configuration
{
    public class ResourceTemplate : IResourceTemplate
    {
        public JObject GetResourceBase(IResourceMember member, IResourceContract contract)
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
