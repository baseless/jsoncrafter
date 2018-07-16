﻿using System;
using JsonCrafter.Serialization.Converters;
using JsonCrafter.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace JsonCrafter.Initialization
{
    public class JsonCrafterOptionsSetup<TConverter> : IConfigureOptions<MvcOptions> where TConverter: class, IResourceConverter
    {
        private readonly TConverter _converter;

        public JsonCrafterOptionsSetup(TConverter converter)
        {
            _converter = Ensure.IsSet(converter);
        }

        public void Configure(MvcOptions options)
        {
            if (string.IsNullOrEmpty(options.FormatterMappings.GetMediaTypeMappingForFormat(_converter.FormatName)))
            {
                options.FormatterMappings.SetMediaTypeMappingForFormat(_converter.FormatName, _converter.MediaTypeHeaderValue);
            }

            options.OutputFormatters.Add(new JsonCrafterOutputFormatter<TConverter>(_converter));
        }
    }
}
