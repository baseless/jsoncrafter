using System;
using JsonCrafter.Configuration.Interfaces;

namespace JsonCrafter.Configuration
{
    public class JsonCrafterBuilderAction : IJsonCrafterBuilderAction
    {
        private readonly Action<IJsonCrafterConfigurationBuilder> _configBuilder;

        public JsonCrafterBuilderAction(Action<IJsonCrafterConfigurationBuilder> configBuilder)
        {
            _configBuilder = configBuilder ?? throw new ArgumentNullException(nameof(configBuilder));
        }

        public void Invoke(IJsonCrafterConfigurationBuilder builder) => _configBuilder.Invoke(builder);
    }
}
