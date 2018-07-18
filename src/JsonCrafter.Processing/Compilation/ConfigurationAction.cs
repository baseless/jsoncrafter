using System;
using JsonCrafter.Processing.Configuration;

namespace JsonCrafter.Processing.Compilation
{
    public class ConfigurationAction : IConfigurationAction
    {
        private readonly Action<IConfigurationBuilder> _configBuilder;

        public ConfigurationAction(Action<IConfigurationBuilder> configBuilder)
        {
            _configBuilder = configBuilder ?? throw new ArgumentNullException(nameof(configBuilder));
        }

        public void Invoke(IConfigurationBuilder configurator) => _configBuilder.Invoke(configurator);
    }
}
