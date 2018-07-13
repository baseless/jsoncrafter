using System;
using JsonCrafterOld.Conversion.Hal;
using JsonCrafterOld.Conversion.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace JsonCrafterOld.Extensions
{
    public static class MvcBuilderExtensions
    {
        public static IMvcBuilder AddHyperMediaFormatters(this IMvcBuilder builder, IHyperMediaConfiguration configuration)
        {
            if (builder == default(IMvcBuilder))
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (configuration == default(IHyperMediaConfiguration))
            {
                throw new ArgumentNullException(nameof(IHyperMediaConfiguration));
            }
             
            var services = builder.Services;
            services.AddSingleton<IHyperMediaConverterHelper, HyperMediaConverterHelper>();

            services.AddHalFormatterServices(configuration); // todo: ability to set on/off

            return builder;
        }
    }
}
