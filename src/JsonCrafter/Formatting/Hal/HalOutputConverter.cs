using System;
using JsonCrafter.Appendices;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonCrafter.Formatting.Hal
{
    public class HalOutputConverter : OutputConverterBase<HalOutputConverter>
    {
        public HalOutputConverter(IAppendixCollection ruleSet, ILogger<HalOutputConverter> logger) : base(ruleSet, logger)
        {
        }

        protected override void FormatObject(Type type, JObject jsonObject, JsonSerializer serializer)
        {
            var rules = AppendixCollection.ForType(type);

            if (rules == null)
            {
                return;
            }

            jsonObject.Add("YES!!", "NO!!!!!!!!!!!");
        }
    }
}
