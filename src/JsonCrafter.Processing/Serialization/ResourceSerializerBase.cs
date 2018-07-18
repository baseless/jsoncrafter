using System;
using JsonCrafter.Core;
using JsonCrafter.Core.Exceptions;
using JsonCrafter.Core.Helpers;
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

        protected ResourceSerializerBase(IHalConfigurationCompiler compiler, ILogger<TConverter> logger)
        {
            Resolver = Ensure.IsSet(compiler).Compile();
            Logger = Ensure.IsSet(logger);
        }
        
        /// <inheritdoc />
        public abstract string FormatName { get; }

        /// <inheritdoc />
        public abstract string MediaTypeHeaderValue { get; }

        /// <inheritdoc />
        public string Serialize(object obj)
        {
            Ensure.IsSet(obj);
            var type = obj.GetType(); // todo: EVALUATE: What should be allowed here? only class? collections?

            if (!type.IsValidResourceType()) // todo: return an http response here instead?
            { 
                throw new JsonCrafterException($"The type of response ({type.FullName}) is not allowed for this json format.");
            }

            if (!Resolver.Contracts.TryGetValue(type, out var contract))
            {
                throw new JsonCrafterException($"Contract for top-level type '{type.FullName}' does not exist. Ensure that 'For<{type.Name}>()' is set.");
            }

            return ConvertResource(new JObject(), type, obj, contract, true).ToString(Formatting.None);
        }

        /// <summary>
        /// The underlying Converter method, responsible for converting a C# object into a JToken.
        /// </summary>
        /// <param name="target">The json object that the C# object will be mapped into</param>
        /// <param name="type">The recieved objects type</param>
        /// <param name="obj">The C# object instance that are being converted.</param>
        /// <param name="contract">The objects TypeContract</param>
        /// <param name="isRoot">If the objectBase is the root element of the response</param>
        /// <returns>The converted JToken objects</returns>
        protected abstract JToken ConvertResource(JObject target, Type type, object obj, IResourceContract contract, bool isRoot = false);

        /// <summary>
        /// Hooks in post-prossecing for the resulting JToken object after it has been construted.
        /// </summary>
        /// <param name="token">The assembled token.</param>
        /// <returns>The post-processed token.</returns>
        protected abstract JToken PostProcessResponseToken(JToken token);
    }
}
