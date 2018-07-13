using System;
using JsonCrafterOld.Conversion.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace JsonCrafterOld.Conversion.JsonApi
{
    public static class JsonApiBootstrapper
    {
        public static void AddJsonApiFormatterServices(this IServiceCollection services, IHyperMediaConfiguration configuration)
        {
            throw new NotImplementedException();
            var builder = new JsonApiAppendixBuilder<JsonApiOutputConverter>();
            configuration.Configure(builder);

            services.TryAddEnumerable(ServiceDescriptor.Singleton(builder.Build()));
            services.TryAddEnumerable(ServiceDescriptor.Transient<HyperMediaOutputConverter<JsonApiOutputConverter>, JsonApiOutputConverter>());
            services.TryAddEnumerable(ServiceDescriptor.Transient<IConfigureOptions<MvcOptions>, HyperMediaOptionsSetup<JsonApiOutputConverter>>());
        }
    }
}
