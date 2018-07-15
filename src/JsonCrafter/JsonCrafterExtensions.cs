using System;
using JsonCrafter.Configuration.Hal;
using JsonCrafter.Configuration.Hal.Interfaces;
using JsonCrafter.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using JsonCrafter.Core;
using JsonCrafter.Serialization.Hal;
using JsonCrafter.Serialization.Hal.Interfaces;

namespace JsonCrafter
{
    public static class JsonCrafterExtensions // todo: CHECK HOW HANDLE ENTITIES BEHIND ENTITIES. /users/{0}/posts{1}. suggestion: use httpcontext to parse routes?
    {
        public static IMvcBuilder AddJsonCrafterFormatters(this IMvcBuilder mvcBuilder, Action<IJsonCrafterBuilder> configBuilder)
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
            services.TryAddEnumerable(ServiceDescriptor.Singleton<IJsonCrafterBuilderAction>(new JsonCrafterBuilderAction(configBuilder)));

            services.AddHalFormatter();

            return mvcBuilder;
        }

        private static void AddHalFormatter(this IServiceCollection services)
        {
            services.TryAddEnumerable(ServiceDescriptor.Transient<IHalResourceContractBuilder, HalResourceContractBuilder>());
            services.TryAddEnumerable(ServiceDescriptor.Transient<IHalResourceConverter, HalResourceConverter>());
            services.AddTransient<IConfigureOptions<MvcOptions>, JsonCrafterOptionsSetup<IHalResourceConverter>>();
        }
    }
}
