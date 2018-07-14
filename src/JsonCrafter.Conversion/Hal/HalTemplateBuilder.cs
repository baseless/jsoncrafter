using JsonCrafter.Conversion.Shared;
using JsonCrafter.Core.Contracts;
using Newtonsoft.Json.Linq;

namespace JsonCrafter.Conversion.Hal
{
    class HalTemplateBuilder : ITemplateBuilder
    {
        public JObject BuildRoot(object obj, ITypeContract contract)
        {
            return new JObject();
        }

        public JObject BuildObject(object obj, ITypeContract contract)
        {
            return new JObject();
        }

        public JObject BuildResource(IMemberContract member, ITypeContract contract)
        {
            return new JObject();
        }
    }
}
