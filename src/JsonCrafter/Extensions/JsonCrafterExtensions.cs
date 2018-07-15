using System;
using JsonCrafter.Configuration.Interfaces;
using JsonCrafter.Contracts;
using JsonCrafter.Contracts.Interfaces;
using JsonCrafter.MediaTypes.Hal;
using JsonCrafter.MediaTypes.Hal.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace JsonCrafter.Extensions
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
            
            services.AddHalFormatter(configBuilder, null);

            return mvcBuilder;
        }

        private static void AddHalFormatter(this IServiceCollection services, Action<IConfigurationBuilder, IUrlHelper> configBuilder, IUrlHelper urlHelper)
        {
            var templateBuilder = new HalTemplateBuilder();
            configBuilder.Invoke(templateBuilder, urlHelper);
            
            services.TryAddEnumerable(ServiceDescriptor.Singleton<IContractResolver<IHalJsonConverter>>(new ContractResolver<IHalJsonConverter>(templateBuilder.BuildTypeTemplates(), templateBuilder.BuildeDefaultTemplate())));
            services.TryAddEnumerable(ServiceDescriptor.Transient<IHalJsonConverter, HalJsonConverter>());
            services.TryAddEnumerable(ServiceDescriptor.Transient<IConfigureOptions<MvcOptions>, JsonCrafterOptionsSetup<IHalJsonConverter>>());
        }

        private static void AddJsonApiFormatter(this IServiceCollection services)
        {

        }
    }
}
