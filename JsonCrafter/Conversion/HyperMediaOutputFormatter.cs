using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;

namespace JsonCrafter.Conversion
{
    public class HyperMediaOutputFormatter : TextOutputFormatter
    {
        private readonly JsonConverter _converter;

        public HyperMediaOutputFormatter(JsonConverter converter, MediaTypeHeaderValue headerValue)
        {
            _converter = converter ?? throw new ArgumentNullException(nameof(converter));

            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
            SupportedMediaTypes.Add(headerValue);
        }

        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var result = JsonConvert.SerializeObject(context.Object, Formatting.None, _converter);
            return context.HttpContext.Response.WriteAsync(result);
        }
    }
}
