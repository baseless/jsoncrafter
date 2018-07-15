using System;
using JsonCrafter.Core.Interfaces;

namespace JsonCrafter.Core
{
    public class JsonCrafterBuilderAction : IJsonCrafterBuilderAction
    {
        private readonly Action<IJsonCrafterBuilder> _configBuilder;

        public JsonCrafterBuilderAction(Action<IJsonCrafterBuilder> configBuilder)
        {
            _configBuilder = configBuilder ?? throw new ArgumentNullException(nameof(configBuilder));
        }

        public void Invoke(IJsonCrafterBuilder builder) => _configBuilder.Invoke(builder);
    }
}
