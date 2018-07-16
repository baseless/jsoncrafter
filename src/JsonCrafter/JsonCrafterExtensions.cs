using System;
using JsonCrafter.Initialization;
using JsonCrafter.Serialization.Build;
using JsonCrafter.Serialization.Configuration;
using JsonCrafter.Shared;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace JsonCrafter
{
    public static class JsonCrafterExtensions
    {
        public static IMvcBuilder AddJsonCrafter(this IMvcBuilder mvcBuilder, Action<IJsonCrafterConfigurator> configurator)
        {
            Ensure.IsSet(mvcBuilder);
            Ensure.IsSet(configurator);

            var services = mvcBuilder.Services;
            services.AddEnabledJsonCrafterAssets(configurator);
            return mvcBuilder;
        }
    }
}
