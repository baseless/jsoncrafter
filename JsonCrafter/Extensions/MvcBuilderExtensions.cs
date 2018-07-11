using System;
using JsonCrafter.Conversion;
using JsonCrafter.Conversion.Hal;
using JsonCrafter.Rules;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

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
            var ruleBuilder = new JsonRuleBuilder();
            configuration.Configure(ruleBuilder);

            services.TryAddEnumerable(ServiceDescriptor.Singleton<IJsonRuleSet>(ruleBuilder.Build())); // Adds the global rulesets.
            
            if (configuration.SupportedMediaTypes.Contains(JsonCrafterConstants.Hal.MediaTypeHeaderValue))
            {
                services.AddHalFormatterServices();
            }
            
            return builder;
        }

        internal static void AddHalFormatterServices(this IServiceCollection services)
        {
            services.TryAddEnumerable(ServiceDescriptor.Singleton<IConverter<HalJsonConverter>, HalJsonConverter>());
            services.TryAddEnumerable(ServiceDescriptor.Transient<IConfigureOptions<MvcOptions>, HalOptionsSetup>());
        }
    }
}
