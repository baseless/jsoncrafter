using System;
using System.IO;
using System.Net;
using System.Text;
using JsonCrafter.Core;
using JsonCrafter.Core.Enums;
using JsonCrafter.Core.Exceptions;
using JsonCrafter.Core.Helpers;
using JsonCrafter.Processing.Compilation.Hal;
using JsonCrafter.Processing.Contracts;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

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
        public string Serialize(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var type = context?.ObjectType;
            var statusCode = context?.HttpContext.Response.StatusCode;

            if (context?.Object == null || statusCode.Equals(HttpStatusCode.NoContent) || statusCode.Equals(HttpStatusCode.ResetContent))
            {
                return string.Empty;
            }

            var stringBuilder = new StringBuilder();
            var stringWriter = new StringWriter(stringBuilder);
            using (var writer = new JsonTextWriter(stringWriter))
            {
                var responseType = type.GetResponseType();

                if (statusCode > 199 && statusCode < 300) // all success statues
                {
                    if (!Resolver.Contracts.TryGetValue(type, out var contract))
                    {
                        throw new JsonCrafterException($"Contract for top-level type '{type.FullName}' does not exist. Ensure that 'For<{type.Name}>()' is set.");
                    }

                    if (responseType.Equals(ResourceResponseType.Collection))
                    {
                        WriteTopLevelArray(writer, type, context.Object, contract);
                    }
                    else
                    {
                        WriteTopLevelObject(writer, type, context.Object, contract);
                    }
                }
                else
                {
                    WriteErrorResponse(writer, type, context.Object);
                }
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// The underlying Converter method, responsible for converting a C# object into a JToken.
        /// </summary>
        /// <param name="writer">The json textwriter instance</param>
        /// <param name="type">The recieved objects type</param>
        /// <param name="instance">The C# object instance that are being converted.</param>
        /// <param name="contract">The objects TypeContract</param>
        protected abstract void WriteTopLevelObject(JsonTextWriter writer, Type type, object instance, IResourceContract contract);

        /// <summary>
        /// Writes the top level array.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="type">The type.</param>
        /// <param name="instance">The instance.</param>
        /// <param name="contract">The contract.</param>
        protected abstract void WriteTopLevelArray(JsonTextWriter writer, Type type, object instance, IResourceContract contract);

        /// <summary>
        /// Writes the error response.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="type">The type.</param>
        /// <param name="instance">The instance.</param>
        protected abstract void WriteErrorResponse(JsonTextWriter writer, Type type, object instance);
    }
}
