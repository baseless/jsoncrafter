using System;
using JsonCrafter.Processing.Configuration;

namespace JsonCrafter.Processing.Compilation
{
    public class SettingsCompilerAction : ISettingsCompilerAction
    {
        private readonly Action<IConfigurationBuilder> _configBuilder;

        public SettingsCompilerAction(Action<IConfigurationBuilder> configBuilder)
        {
            _configBuilder = configBuilder ?? throw new ArgumentNullException(nameof(configBuilder));
        }

        public void Invoke(IConfigurationBuilder configurator) => _configBuilder.Invoke(configurator);
    }
}
