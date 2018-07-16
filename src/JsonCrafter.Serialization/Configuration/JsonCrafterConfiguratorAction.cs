using System;

namespace JsonCrafter.Serialization.Configuration
{
    public class JsonCrafterConfiguratorAction : IJsonCrafterConfiguratorAction
    {
        private readonly Action<IJsonCrafterConfigurator> _configBuilder;

        public JsonCrafterConfiguratorAction(Action<IJsonCrafterConfigurator> configBuilder)
        {
            _configBuilder = configBuilder ?? throw new ArgumentNullException(nameof(configBuilder));
        }

        public void Invoke(IJsonCrafterConfigurator configurator) => _configBuilder.Invoke(configurator);
    }
}
