using System;
using JsonCrafter.Core;
using JsonCrafter.Core.Exceptions;
using JsonCrafter.Processing.Compilation.Hal;
using JsonCrafter.Processing.Contracts;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonCrafter.Processing.Serialization
{
    /// <summary>
    /// Base class for C# Object to JToken conversion.
    /// </summary>
    public abstract class ResourceSerializerBase<TConverter> : IResourceSerializer where TConverter : class, IResourceSerializer
    {
        protected readonly IResourceContractResolver Resolver;
        protected readonly ILogger<TConverter> Logger;

        protected ResourceSerializerBase(IHalSettingsCompiler compiler, ILogger<TConverter> logger)
        {
            Resolver = Ensure.IsSet(compiler).Compile();
            Logger = Ensure.IsSet(logger);
        }

        public abstract string FormatName { get; }
        public abstract string MediaTypeHeaderValue { get; }

        /// <summary>
        /// Initializes the conversion chain using the recieved object.
        /// </summary>
        /// <param name="obj">The C# object that is about to be presented as a result to the consumer.</param>
        /// <returns></returns>
        public string Serialize(object obj)
        {
            var type = obj.GetType();
            Ensure.IsValidResource(type, obj);

            var contract = Resolver.Resolve(type) 
                           ?? throw new JsonCrafterException($"Contract for type '{type.FullName}' does not exist (top-level object MUST be a configured resource). Ensure that 'For<{type.Name}>()' is set.");

            return ConvertBase(new JObject(), type, obj, contract, true).ToString(Formatting.None);
        }

        /// <summary>
        /// The underlying Converter method, responsible for converting a C# object into a JToken.
        /// </summary>
        /// <param name="target">The json object that the C# object will be mapped into</param>
        /// <param name="type">The recieved objects type</param>
        /// <param name="obj">The C# object instance that are being converted.</param>
        /// <param name="contract">The objects TypeContract</param>
        /// <param name="isRoot">If the objectBase is the root element of the response</param>
        /// <returns></returns>
        protected abstract JToken ConvertBase(JObject target, Type type, object obj, IResourceContract contract, bool isRoot = false);

        protected abstract JToken PostProcessResult(JToken token);

        JToken IResourceSerializer.Convert(object obj)
        {
            return JToken.FromObject(obj);
        }
    }
}
