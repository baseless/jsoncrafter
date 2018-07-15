using System;
using JsonCrafter.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JsonCrafter
{
    public static class JsonCrafterExtensions
    {
        public static IMvcBuilder AddJsonCrafterFormatters(this IMvcBuilder mvcBuilder, Action<IJsonCrafterConfigurator> configurator)
        {
            if (mvcBuilder == default(IMvcBuilder))
            {
                throw new ArgumentNullException(nameof(mvcBuilder));
            }

            if (configurator == default(Action<IJsonCrafterConfigurator>))
            {
                throw new ArgumentNullException(nameof(configurator));
            }

            var services = mvcBuilder.Services;

            services.AddEnabledFormatters();

            return mvcBuilder;
        }

        private static void AddEnabledFormatters(this IServiceCollection services)
        {
            services.AddHalFormatter();
        }

        private static void AddHalFormatter(this IServiceCollection services)
        {
        }
    }
}
