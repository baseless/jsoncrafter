using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;

namespace JsonCrafterOld.Conversion.Shared
{
    public class HyperMediaOutputFormatter<TConverter> : TextOutputFormatter where TConverter: class
    {
        private readonly JsonConverter _converter;

        public HyperMediaOutputFormatter(HyperMediaOutputConverter<TConverter> converter)
        {
            _converter = converter ?? throw new ArgumentNullException(nameof(converter));

            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse(converter.MediaTypeHeaderValue));
        }

        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var result = JsonConvert.SerializeObject(context.Object, Newtonsoft.Json.Formatting.None, _converter);
            return context.HttpContext.Response.WriteAsync(result);
        }
    }
}
