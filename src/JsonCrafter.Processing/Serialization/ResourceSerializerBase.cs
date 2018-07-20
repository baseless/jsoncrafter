using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using JsonCrafter.Core;
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
        protected readonly ITypeContractResolver Resolver;
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
        public async Task<string> SerializeAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var statusCode = context?.HttpContext.Response.StatusCode;

            if (context?.Object == null || statusCode.Equals(HttpStatusCode.NoContent) || statusCode.Equals(HttpStatusCode.ResetContent))
            {
                return string.Empty;
            }
            
            var stringBuilder = new StringBuilder();
            var stringWriter = new StringWriter(stringBuilder);
            using (var writer = new JsonTextWriter(stringWriter))
            {
                if (statusCode > 199 && statusCode < 300) // all success statues
                {
                    if (!Resolver.Contracts.TryGetValue(context.ObjectType, out var contract))
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotAcceptable;
                        return string.Empty;
                    }

                    await contract.WriteAsync(context.Object, writer);
                }
                else
                {
                    throw new NotImplementedException("Error responses not supported (yet)");
                }
            }

            return stringBuilder.ToString();
        }
    }
}
