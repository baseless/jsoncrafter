using System;
using System.Linq;
using JsonCrafter.Appendices;
using JsonCrafter.Reflection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonCrafter.Formatting
{
    public abstract class OutputConverterBase<TConverter> : JsonConverter, IConverter<TConverter> where TConverter : JsonConverter
    {
        protected readonly IAppendixCollection AppendixCollection;
        protected readonly IJsonCrafterReflectionService ReflectionService;
        private readonly ILogger<TConverter> _logger;

        protected OutputConverterBase(IAppendixCollection collection, ILogger<TConverter> logger)  // https://github.com/aspnet/Logging/issues/493
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

        protected abstract void FormatObject(Type type, JObject jsonObject, JsonSerializer serializer);
    }
}
