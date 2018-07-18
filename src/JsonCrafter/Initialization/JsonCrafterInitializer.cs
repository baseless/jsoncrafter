using System;
using System.Collections.Immutable;
using System.Linq;
using JsonCrafter.Core.Enums;
using JsonCrafter.Core.Exceptions;
using JsonCrafter.Processing.Compilation;
using JsonCrafter.Processing.Compilation.Hal;
using JsonCrafter.Processing.Configuration;
using JsonCrafter.Processing.Naming;
using JsonCrafter.Processing.Serialization.Hal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace JsonCrafter.Initialization
{
    internal static class JsonCrafterInitializer
    {
        internal static IImmutableList<JsonCrafterMediaType> EnabledMediaTypes;

        internal static void AddEnabledJsonCrafterAssets(this IServiceCollection services, Action<IConfigurationBuilder> configurator)
        {
            services.TryAddSingleton<IConfigurationAction>(new ConfigurationAction(configurator));
            
            var config = new HalConfigurationCompiler(new SnakeCaseFormatter());
            configurator.Invoke(config);

            foreach (var settingsColl in config.Resources)
            {
                var typeName = settingsColl.Key.Name;
                var settings = settingsColl.Value.Settings.ToList();
            }

            EnabledMediaTypes = config.EnabledMediaTypes.ToImmutableList();

            services.AddCasingStrategy(config.GetCasing());

            if (EnabledMediaTypes.Contains(JsonCrafterMediaType.Hal))
            {
                services.AddHalFormatter();
            }
        }
        
        private static void AddHalFormatter(this IServiceCollection services)
        {
            services.AddTransient<IHalConfigurationCompiler, HalConfigurationCompiler>();
            services.AddTransient<IHalSerializer, HalSerializer>();
            services.AddTransient<IConfigureOptions<MvcOptions>, JsonCrafterOptionsSetup<IHalSerializer>>();
        }

        private static void AddCasingStrategy(this IServiceCollection services, JsonCrafterCasing casing)
        {
            switch (casing)
            {
                case JsonCrafterCasing.CamelCase:
                    services.AddSingleton<ICaseFormatter, CamelCaseFormatter>();
                    break;
                case JsonCrafterCasing.PascalCase:
                    services.AddSingleton<ICaseFormatter, PascalCaseFormatter>();
                    break;
                case JsonCrafterCasing.SnakeCase:
                    services.AddSingleton<ICaseFormatter, SnakeCaseFormatter>();
                    break;
                case JsonCrafterCasing.ParamCase:
                    services.AddSingleton<ICaseFormatter, ParamCaseFormatter>();
                    break;
                default:
                    throw new JsonCrafterException($"Could not activate casing strategy '{casing.ToString()}' (not supported)");
            }
        }
    }
}
