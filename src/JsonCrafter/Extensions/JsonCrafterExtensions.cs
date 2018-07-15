﻿using System;
using JsonCrafter.Conversion.Hal;
using JsonCrafter.Conversion.Hal.Interfaces;
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
