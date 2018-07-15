using System;
using JsonCrafter.Configuration.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JsonCrafter.Configuration
{
    public class JsonCrafterBuilderAction : IJsonCrafterBuilderAction
    {
        private readonly Action<IJsonCrafterConfigurationBuilder, IUrlHelper> _configBuilder;

        public JsonCrafterBuilderAction(Action<IJsonCrafterConfigurationBuilder, IUrlHelper> configBuilder)
        {
            _configBuilder = configBuilder ?? throw new ArgumentNullException(nameof(configBuilder));
        }

        public void Invoke(IJsonCrafterConfigurationBuilder builder, IUrlHelper urlHelper) => _configBuilder.Invoke(builder, urlHelper);
    }
}
