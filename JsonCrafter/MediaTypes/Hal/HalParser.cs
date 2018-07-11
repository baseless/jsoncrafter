using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using JsonCrafter.Interfaces;
using Newtonsoft.Json.Linq;

namespace JsonCrafter.MediaTypes.Hal
{
    public class HalParser : FormatterParserBase<HalOutputFormatter>
    {
        private readonly IImmutableDictionary<Type, KeyValuePair<string, string>> _configuration;

        public HalParser(IFormatterConfiguration configuration)
        {
            _configuration = configuration?.Configuration ?? throw new ArgumentNullException(nameof(configuration.Configuration));
        }

        protected override bool ParseBase(JObject obj)
        {
            obj.Add("JObjectProp", "Injected!");
            return true;
        }
    }
}
