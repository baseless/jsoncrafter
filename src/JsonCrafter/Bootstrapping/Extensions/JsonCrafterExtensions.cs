using System;
using JsonCrafter.Construction;
using JsonCrafter.Construction.Hal;
using JsonCrafter.Serialization.Hal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace JsonCrafter.Bootstrapping.Extensions
{
    public static class JsonCrafterExtensions
    {
        public static IMvcBuilder AddJsonCrafterFormatters(this IMvcBuilder mvcBuilder, Action<IConfigurationBuilder, IUrlHelper> configBuilder)
        {
            if (mvcBuilder == default(IMvcBuilder))
            {
                throw new ArgumentNullException(nameof(mvcBuilder));
            }
            
            if (configBuilder == null)
            {
                throw new ArgumentNullException(nameof(configBuilder));
            }

            var services = mvcBuilder.Services;
            services.AddHttpContextAccessor(); // todo: check and only added if not already added?
            services.AddHalFormatter(configBuilder);

            return mvcBuilder;
        }

        private static void AddHalFormatter(this IServiceCollection services, Action<IConfigurationBuilder, IUrlHelper> configBuilder)
        {
            // Hal IOC
            services.TryAddEnumerable(ServiceDescriptor.Singleton<IHalContractBuilder>(new HalContractBuilder(configBuilder)));
            services.TryAddEnumerable(ServiceDescriptor.Transient<IHalJsonConverter, HalJsonConverter>());

            // Generic IOC
            services.TryAddEnumerable(ServiceDescriptor.Transient<IConfigureOptions<MvcOptions>, JsonCrafterOptionsSetup<IHalJsonConverter>>());
        }

        private static void AddJsonApiFormatter(this IServiceCollection services)
        {

        }
    }
}
