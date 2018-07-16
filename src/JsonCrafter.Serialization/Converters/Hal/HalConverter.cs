using JsonCrafter.Build;
using JsonCrafter.Build.Hal;
using JsonCrafter.Shared;
using Newtonsoft.Json.Linq;

namespace JsonCrafter.Serialization.Converters.Hal
{
    public class HalConverter : IResourceConverter, IHalConverter
    {
        private readonly IHalConfigurationFactory _factory;
        public HalConverter(IHalConfigurationFactory factory)
        {
            _factory = Ensure.IsSet(factory);
        }

        public string FormatName => JsonCrafterConstants.Hal.FormatName;

        public string MediaTypeHeaderValue => JsonCrafterConstants.Hal.MediaTypeHeaderValue;

        public IJsonCrafterConfiguratorFactory ConfigurationFactory => _factory;

        public JToken Convert(object obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
