using System.Text;
using System.Threading.Tasks;
using JsonCrafter.Core;
using JsonCrafter.Processing.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;

namespace JsonCrafter.Initialization
{
    public class JsonCrafterOutputFormatter<TConverter> : TextOutputFormatter where TConverter : class, IResourceSerializer
    {
        private readonly TConverter _converter;

        public JsonCrafterOutputFormatter(TConverter converter)
        {
            _converter = Ensure.IsSet(converter);
            //todo: IMPLEMENT: Handle casing and encoding correctly
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse(converter.MediaTypeHeaderValue));
        }

        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var token = _converter.Convert(context.Object);
            return context.HttpContext.Response.WriteAsync(JsonConvert.SerializeObject(token));
        }
    }
}
