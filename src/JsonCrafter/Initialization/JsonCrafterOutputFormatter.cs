using System.Text;
using System.Threading.Tasks;
using JsonCrafter.Core;
using JsonCrafter.Processing.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;

namespace JsonCrafter.Initialization
{
    public class JsonCrafterOutputFormatter<TSerializer> : TextOutputFormatter where TSerializer : class, IResourceSerializer
    {
        private readonly TSerializer _serializer;

        public JsonCrafterOutputFormatter(TSerializer serializer)
        {
            _serializer = Ensure.IsSet(serializer);
            //todo: IMPLEMENT: Handle encoding amd content / mediatyp correctly
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse(serializer.MediaTypeHeaderValue));
        }

        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var response = _serializer.Serialize(context.Object);
            return context.HttpContext.Response.WriteAsync(response);
        }
    }
}
