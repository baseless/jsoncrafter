using System;
using JsonCrafter.Appendices;
using JsonCrafter.Conversion;
using JsonCrafter.Conversion.Hal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace JsonCrafter.Extensions
{
    public static class MvcBuilderExtensions
    {
        public static IMvcBuilder AddHyperMediaSerializationFormatters(this IMvcBuilder builder, IFormatterConfiguration configuration)
        {
            if (builder == default(IMvcBuilder))
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (configuration == default(IFormatterConfiguration))
            {
                throw new ArgumentNullException(nameof(IFormatterConfiguration));
            }
             
            var services = builder.Services;
            var ruleBuilder = new AppendixBuilder();
            configuration.Configure(ruleBuilder);

            services.TryAddEnumerable(ServiceDescriptor.Singleton<IAppendixCollection>(ruleBuilder.Build())); // Adds the global rulesets.
            
            if (configuration.SupportedMediaTypes.Contains(JsonCrafterConstants.Hal.MediaTypeHeaderValue))
            {
                services.AddHalFormatterServices();
            }
            
            return builder;
        }
    }
}
