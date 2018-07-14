using System;
using JsonCrafter.Conversion.Hal;
using JsonCrafter.Conversion.Hal.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using JsonCrafter.Core.Configuration.Interfaces;
using JsonCrafter.Core.Contracts;
using JsonCrafter.Core.Contracts.Interfaces;
using TypeHandler = JsonCrafter.Core.Helpers.TypeHelper;

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
            
            services.AddHalFormatter();

            return builder;
        }

        private static void AddHalFormatter(this IServiceCollection services)
        {
            services.TryAddEnumerable(ServiceDescriptor.Transient<IContractResolver<IHalJsonConverter>, ContractResolver<IHalJsonConverter>>());
            services.TryAddEnumerable(ServiceDescriptor.Transient<IHalJsonConverter, HalJsonConverter>());
            services.TryAddEnumerable(ServiceDescriptor.Transient<IConfigureOptions<MvcOptions>, JsonCrafterOptionsSetup<IHalJsonConverter>>());
        }

        private static void AddJsonApiFormatter(this IServiceCollection services)
        {

        }
    }
}
