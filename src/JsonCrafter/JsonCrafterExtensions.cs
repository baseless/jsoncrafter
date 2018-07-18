using System;
using JsonCrafter.Core;
using JsonCrafter.Initialization;
using JsonCrafter.Processing.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JsonCrafter
{
    // todo: (FUTURE)BUILD - HasQueryParam("") which gets its param from querystring
    // todo: (FUTURE)BUILD - a facade for responses to add properties outside the returned model.
    // todo: (FUTURE)BUILD - hard typed url support (like Url.Action() but without context requirement).
    // todo: (FUTURE)INVESTIGATE - options for retrieving parameters from external sources like databases.
    // todo: (IMPORTANT)BUILD - Abstract the fluent configurationbuilder so that a annotationbuilder can easily be added later.
    // todo: INVESTIGATE - Should dependency inject be worked out (what happens if user decides to switch IOC framework for example?)
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
