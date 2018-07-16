using System;
using JsonCrafter.Build;
using JsonCrafter.Configuration;
using JsonCrafter.Shared.Enums;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace JsonCrafter.Initialization
{
    internal static class JsonCrafterInitializer
    {
        internal static void AddEnabledJsonCrafterAssets(this IServiceCollection services, Action<IJsonCrafterConfigurator> configurator)
        {
            // Add global dependencis
            services.TryAddSingleton<IJsonCrafterConfiguratorAction>(new JsonCrafterConfiguratorAction(configurator));

            // Process applicable configurationsettings
            var config = new JsonCrafterConfigurationFetcher();
            configurator.Invoke(config);

            if (config.EnabledMediaTypes.Contains(JsonCrafterMediaType.Hal))
            {
                services.AddHalFormatter();
            }
        }
        
        private static void AddHalFormatter(this IServiceCollection services)
        {

        }
    }
}
