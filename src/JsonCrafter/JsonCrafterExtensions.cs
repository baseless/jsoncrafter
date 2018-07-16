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

        public static IApplicationBuilder UseJsonCrafter(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var r = scope.ServiceProvider.GetRequiredService<IJsonCrafterResolverFactory>();
                //todo: IMPLEMENT: configuration build and prepare contracts and so forth.
            }

            return app;
        }
    }
}
