using System;
using JsonCrafter.Initialization;
using JsonCrafter.Serialization.Configuration;
using JsonCrafter.Shared;
using Microsoft.Extensions.DependencyInjection;

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
