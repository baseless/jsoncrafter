using System;
using JsonCrafter.Conversion.Hal;
using JsonCrafter.Conversion.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using JsonCrafter.Core.Configuration;
using JsonCrafter.Core.Contracts;
using JsonCrafter.Core.Helpers;
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

            //services.TryAddEnumerable(ServiceDescriptor.Transient<ITypeHandler, TypeHandler>());
            services.TryAddEnumerable(ServiceDescriptor.Singleton<ITokenConverter, TokenConverter>());
            services.TryAddEnumerable(ServiceDescriptor.Singleton<ITypeHelper, TypeHelper>());
            services.TryAddEnumerable(ServiceDescriptor.Singleton<IContractResolver, ContractResolver>());

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
