using System;
using System.Linq;
using JsonCrafterOld.Appendices;
using JsonCrafterOld.Reflection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonCrafterOld.Conversion.Shared
{
    public abstract class HyperMediaOutputConverter<TConverter> : JsonConverter where TConverter : class
    {
        protected readonly IAppendixCollection<TConverter> AppendixCollection;
        protected readonly IJsonCrafterReflectionService ReflectionService;
        private readonly ILogger<TConverter> _logger;

        protected HyperMediaOutputConverter(IAppendixCollection<TConverter> collection, ILogger<TConverter> logger)  // https://github.com/aspnet/Logging/issues/493
        {
            AppendixCollection = collection ?? throw new ArgumentNullException(nameof(collection));
            ReflectionService = new JsonCrafterReflectionService();
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) =>
            throw new NotImplementedException();

        public override bool CanRead => 
            false;
        
        public override bool CanConvert(Type objectType) => 
            true;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var objectType = value.GetType();
            
            var token = JToken.FromObject(value);
            _logger.LogDebug("Processing json {type} response..", token.Type);

            if (token.Type.Equals(JTokenType.Object) && token is JObject obj)
            {
                FormatObject(objectType, obj, serializer);
            }
            else if (token.Type.Equals(JTokenType.Array) && token is JArray arr)
            {
                foreach (var o in arr.Where(t => t.Type.Equals(JTokenType.Object)).Cast<JObject>())
                {
                    FormatObject(objectType, o, serializer);
                }
            }
            else
            {
                _logger.LogWarning("Response was not recognozed as array or object, writing as pure json instead..");
            }

            token.WriteTo(writer);
        }

        public abstract string FormatName { get; }

        public abstract string MediaTypeHeaderValue { get; }

        protected abstract void FormatObject(Type type, JObject jsonObject, JsonSerializer serializer);
    }
}
