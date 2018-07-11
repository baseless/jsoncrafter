using System;
using JsonCrafter.Interfaces;
using JsonCrafter.MediaTypes.Hal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace JsonCrafter.Extensions
{
    public static class MvcBuilderExtensions
    {
        public static IMvcBuilder AddHyperMediaSerializationFormatters<TConfiguration>(this IMvcBuilder builder, JsonFormatterOptions options = null) where TConfiguration: class, IFormatterConfiguration
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            var services = builder.Services;

            services.TryAddEnumerable(ServiceDescriptor.Singleton<IFormatterConfiguration, TConfiguration>()); // Adds the global formatter-configuration.

            options = options ?? new JsonFormatterOptions();

            if (options.EnableHalSerialization)
            {
                services.AddHalFormatterServices();
            }

            if (options.EnableJsonApiSerialization)
            {
                services.AddJsonApiFormatterServices();
            }

            return builder;
        }

        internal static void AddHalFormatterServices(this IServiceCollection services)
        {
            services.TryAddEnumerable(ServiceDescriptor.Singleton<Interfaces.IFormatterParser<HalOutputFormatter>, HalParser>());
            services.TryAddEnumerable(ServiceDescriptor.Transient<IConfigureOptions<MvcOptions>, HalOptionsSetup>());
        }

        internal static void AddJsonApiFormatterServices(this IServiceCollection services)
        {
            throw new NotImplementedException();
        }
    }
}
