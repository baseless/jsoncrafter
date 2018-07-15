using System;
using JsonCrafterOld.Configuration.Hal;
using JsonCrafterOld.Configuration.Hal.Interfaces;
using JsonCrafterOld.Core;
using JsonCrafterOld.Core.Interfaces;
using JsonCrafterOld.Serialization.Hal;
using JsonCrafterOld.Serialization.Hal.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace JsonCrafterOld
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
