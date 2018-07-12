using System;
using JsonCrafter.Rules.Parsed;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonCrafter.Conversion.Hal
{
    public class HalOutputConverter : OutputConverterBase
    {
        public HalOutputConverter(IRuleCollection ruleSet) : base(ruleSet)
        {
        }

        protected override void FormatObject(Type type, JObject jsonObject, JsonSerializer serializer)
        {
            var rules = Rules.GetRulesForType(type);

            jsonObject.Add("YES!!", "NO!!!!!!!!!!!");
        }
    }
}
