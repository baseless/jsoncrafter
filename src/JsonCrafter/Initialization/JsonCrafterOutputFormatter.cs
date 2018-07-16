﻿using System;
using System.Text;
using System.Threading.Tasks;
using JsonCrafter.Serialization.Contracts;
using JsonCrafter.Serialization.Converters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;

namespace JsonCrafter.Initialization
{
    public class JsonCrafterOutputFormatter<TConverter> : TextOutputFormatter where TConverter : class, IResourceConverter
    {
        private readonly TConverter _converter;
        private bool _isBuilt = false;

        public JsonCrafterOutputFormatter(TConverter converter)
        {
            _converter = converter ?? throw new NotImplementedException(nameof(converter));
            //todo: enable selection of encoding and json name casing strategies (camel, snake, kebab)
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse(converter.MediaTypeHeaderValue));
        }

        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            
            // todo: BUILD INDEX HERE IF NOT BUILT?
            var token = _converter.Convert(context.Object);
            return context.HttpContext.Response.WriteAsync(token.ToString(Formatting.None));
        }
    }
}