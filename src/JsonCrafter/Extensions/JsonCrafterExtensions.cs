using System;
using System.Collections.Generic;
using JsonCrafter.Conversion.Hal;
using JsonCrafter.Conversion.Hal.Interfaces;
using JsonCrafter.Core.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using JsonCrafter.Core.Configuration.Interfaces;
using JsonCrafter.Core.Contracts;
using JsonCrafter.Core.Contracts.Interfaces;

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
            // todo: construct the contractresolver using a builder
            services.TryAddEnumerable(ServiceDescriptor.Singleton<IContractResolver<IHalJsonConverter>>(new ContractResolver<IHalJsonConverter>(new Dictionary<Type, ITypeTemplate>(), new TypeTemplate())));
            services.TryAddEnumerable(ServiceDescriptor.Transient<IHalJsonConverter, HalJsonConverter>());
            services.TryAddEnumerable(ServiceDescriptor.Transient<IConfigureOptions<MvcOptions>, JsonCrafterOptionsSetup<IHalJsonConverter>>());
        }

        private static void AddJsonApiFormatter(this IServiceCollection services)
        {

        }
    }
}
