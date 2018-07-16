﻿using System;
using System.Collections.Immutable;
using System.Linq;
using JsonCrafter.Serialization.Build;
using JsonCrafter.Serialization.Build.Hal;
using JsonCrafter.Serialization.Configuration;
using JsonCrafter.Shared.Enums;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace JsonCrafter.Initialization
{
    internal static class JsonCrafterInitializer
    {
        internal static IImmutableList<JsonCrafterMediaType> EnabledMediaTypes;

        internal static void AddEnabledJsonCrafterAssets(this IServiceCollection services, Action<IJsonCrafterConfigurator> configurator)
        {
            // Add global dependencis
            services.TryAddSingleton<IJsonCrafterConfiguratorAction>(new JsonCrafterConfiguratorAction(configurator));

            // Process applicable configurationsettings
            var config = new JsonCrafterConfiguratorBase();
            configurator.Invoke(config);
            EnabledMediaTypes = config.EnabledMediaTypes.ToImmutableList();

            if (EnabledMediaTypes.Contains(JsonCrafterMediaType.Hal))
            {
                services.AddHalFormatter();
            }
        }
        
        private static void AddHalFormatter(this IServiceCollection services)
        {
            services.AddSingleton<IHalResolverFactory, HalResolverFactory>();
            services.AddTransient<IJsonCrafterResolverFactory, HalResolverFactory>();
        }
    }
}