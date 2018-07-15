using JsonCrafter.Configuration.Interfaces;
using JsonCrafter.Conversion.Interfaces;
using JsonCrafter.Settings;
using Newtonsoft.Json.Linq;

namespace JsonCrafter.ContentTypes.Hal
{
    public class HalResourceTemplate : IResourceTemplate
    {
        public JObject NewResource(IResourceMember member, IResourceContract contract)
        {
            return new JObject();
        }

        public JObject NewRoot(object obj) => JObject.Parse(JsonCrafterConstants.Hal.Templates.Root);

        public JObject NewObject(object obj) => JObject.Parse(JsonCrafterConstants.Hal.Templates.Object);
    }
}
