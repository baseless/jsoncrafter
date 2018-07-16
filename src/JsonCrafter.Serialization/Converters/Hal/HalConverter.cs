using JsonCrafter.Serialization.Build;
using JsonCrafter.Serialization.Build.Hal;
using JsonCrafter.Shared;
using Newtonsoft.Json.Linq;

namespace JsonCrafter.Serialization.Converters.Hal
{
    public class HalConverter : IResourceConverter, IHalConverter
    {
        private readonly IHalResolverFactory _factory;
        public HalConverter(IHalResolverFactory factory)
        {
            _factory = Ensure.IsSet(factory);
        }

        public string FormatName => JsonCrafterConstants.Hal.FormatName;

        public string MediaTypeHeaderValue => JsonCrafterConstants.Hal.MediaTypeHeaderValue;

        public IJsonCrafterResolverFactory ConfigurationFactory => _factory;

        public JToken Convert(object obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
