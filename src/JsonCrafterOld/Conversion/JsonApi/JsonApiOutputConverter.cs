using System;
using JsonCrafterOld.Appendices;
using JsonCrafterOld.Conversion.Shared;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonCrafterOld.Conversion.JsonApi
{
    public class JsonApiOutputConverter : HyperMediaOutputConverter<JsonApiOutputConverter>
    {
        public JsonApiOutputConverter(IAppendixCollection<JsonApiOutputConverter> collection, ILogger<JsonApiOutputConverter> logger) : base(collection, logger)
        {
        }

        public override string FormatName => JsonCrafterConstants.JsonApi.FormatName;

        public override string MediaTypeHeaderValue => JsonCrafterConstants.JsonApi.MediaTypeHeaderValue;

        protected override void FormatObject(Type type, JObject jsonObject, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
