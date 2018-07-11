using System;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using JsonCrafter.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace JsonCrafter
{
    public abstract class HyperMediaOutputFormatterBase<TOutputFormatter> : TextOutputFormatter
    {
        private readonly ILoggerFactory _loggerFactory;

        private readonly IFormatterParser<TOutputFormatter> _parser;
        
        private readonly string _headerValue;

        protected HyperMediaOutputFormatterBase(ILoggerFactory loggerFactory, IFormatterParser<TOutputFormatter> parser, string headerValue)
        {
            _loggerFactory = loggerFactory ?? throw new ArgumentNullException(nameof(ILoggerFactory));
            _parser = parser ?? throw new ArgumentNullException(nameof(IFormatterParser<TOutputFormatter>));
            _headerValue = headerValue ?? throw new ArgumentNullException(nameof(headerValue));

            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse(_headerValue));
        }

        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response;

            if (JToken.FromObject(context.Object) is JToken token)
            {
                var result = token.Type.Equals(JTokenType.Array)
                    ? _parser.Parse(token as JArray)
                    : _parser.Parse(token as JObject);

                if (result.Succeeded)
                {
                    return response.WriteAsync(result.Content);
                }
            }

            _loggerFactory.CreateLogger<TOutputFormatter>()
                .LogError("Failed to convert object of type {OBJTYPE} to hal+json", context.Object.GetType().FullName); ;

            response.StatusCode = StatusCodes.Status500InternalServerError;
            response.ContentType = MediaTypeNames.Text.Plain;
            return response.WriteAsync($"Could not serve result as {_headerValue}.");
        }
    }
}
