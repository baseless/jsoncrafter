using System;
using JsonCrafter.Conversion.Hal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using JsonCrafter.Core.Configuration;
using JsonCrafter.Core.Handlers;

namespace JsonCrafter.Extensions
{
    public static class JsonCrafterExtensions
    {
        public static IMvcBuilder AddJsonCrafterFormatters(this IMvcBuilder builder, IJsonCrafterConfiguration configuration)
        {
            if (builder == default(IMvcBuilder))
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (configuration == default(IJsonCrafterConfiguration))
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            var services = builder.Services;

            services.TryAddEnumerable(ServiceDescriptor.Transient<ITypeHandler, TypeHandler>());

            services.AddHalFormatter();

            return builder;
        }

        private static void AddHalFormatter(this IServiceCollection services)
        {
            services.TryAddEnumerable(ServiceDescriptor.Singleton<IHalJsonConverter, HalJsonConverter>());
            services.TryAddEnumerable(ServiceDescriptor.Transient<IConfigureOptions<MvcOptions>, JsonCrafterOptionsSetup<IHalJsonConverter>>());
        }

        private static void AddJsonApiFormatter(this IServiceCollection services)
        {

        }
    }
}
