using System;
using JsonCrafterOld.Appendices;
using JsonCrafterOld.Conversion.Shared;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonCrafterOld.Conversion.Hal
{
    public class HalOutputConverter : HyperMediaOutputConverter<HalOutputConverter>
    {
        private readonly IHyperMediaConverterHelper _converterHelper;

        public HalOutputConverter(IAppendixCollection<HalOutputConverter> ruleSet, ILogger<HalOutputConverter> logger, IHyperMediaConverterHelper converterHelper) : base(ruleSet, logger)
        {
            _converterHelper = converterHelper ?? throw new NotImplementedException(nameof(converterHelper));
        }

        public override string FormatName => JsonCrafterConstants.Hal.FormatName;

        public override string MediaTypeHeaderValue => JsonCrafterConstants.Hal.MediaTypeHeaderValue;

        protected override void FormatObject(Type type, JObject jsonObject, JsonSerializer serializer)
        {
            var appendixSet = AppendixCollection.ForType(type);
            //if (rules == null)
            //{
            //    return;
            //}

            string[] propNames = {"Id", "Id2", "Id3"};

            var paramValues = _converterHelper.GetValuesFromPropertyNames(jsonObject, propNames);
            var prop = _converterHelper.ConvertToProperty(JsonCrafterConstants.Hal.Formatting.LinkObject, _linksTemplate, paramValues);
            jsonObject.AddFirst(prop);

            var paramValues2 = _converterHelper.GetValuesFromPropertyNames(jsonObject, propNames);
            var prop2 = _converterHelper.ConvertToProperty(JsonCrafterConstants.Hal.Formatting.LinkObject + 2, _linksTemplate, paramValues2);
            jsonObject.AddFirst(prop2);

            var paramValues3 = _converterHelper.GetValuesFromPropertyNames(jsonObject, propNames);
            var prop3 = _converterHelper.ConvertToProperty(JsonCrafterConstants.Hal.Formatting.LinkObject + 3, _linksTemplate, paramValues3);
            jsonObject.AddFirst(prop3);
        }

        private string _linksTemplate = "{{ 'self': 'http://baba/{0}', 'next': 'http://babas/page={1}', 'prev': 'http://babas/page={2}' }}";
        private string[] _parameterNames = { "Id", "#page", "#page" };
    }
}
