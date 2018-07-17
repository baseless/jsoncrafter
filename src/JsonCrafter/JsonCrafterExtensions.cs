using System;
using JsonCrafter.Core;
using JsonCrafter.Initialization;
using JsonCrafter.Processing.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JsonCrafter
{
    public static class JsonCrafterExtensions
    {
        public static IMvcBuilder AddJsonCrafter(this IMvcBuilder mvcBuilder, Action<IConfigurationBuilder> configurator)
        {
            Ensure.IsSet(mvcBuilder);
            Ensure.IsSet(configurator);

            var services = mvcBuilder.Services;
            services.AddEnabledJsonCrafterAssets(configurator);
            return mvcBuilder;
        }
    }
}
