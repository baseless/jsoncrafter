using JsonCrafterOld.Conversion.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace JsonCrafterOld.Conversion.Hal
{
    public static class HalBootstrapper
    {
        public static void AddHalFormatterServices(this IServiceCollection services, IHyperMediaConfiguration configuration)
        {
            var builder = new HalAppendixBuilder<HalOutputConverter>();
            configuration.Configure(builder);

            services.TryAddEnumerable(ServiceDescriptor.Singleton(builder.Build()));
            services.TryAddEnumerable(ServiceDescriptor.Transient<HyperMediaOutputConverter<HalOutputConverter>, HalOutputConverter>());
            services.TryAddEnumerable(ServiceDescriptor.Transient<IConfigureOptions<MvcOptions>, HyperMediaOptionsSetup<HalOutputConverter>>());
        }
    }
}
