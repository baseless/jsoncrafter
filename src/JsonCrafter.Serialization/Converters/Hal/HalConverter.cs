using JsonCrafter.Serialization.Build;
using JsonCrafter.Serialization.Build.Hal;
using JsonCrafter.Shared;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace JsonCrafter.Serialization.Converters.Hal
{
    public class HalConverter : IResourceConverter, IHalConverter
    {
        private readonly IContractResolver _resolver;

        public HalConverter(IHalResolverFactory factory)
        {
            _resolver = Ensure.IsSet(factory).Create();
        }

        public string FormatName => JsonCrafterConstants.Hal.FormatName;

        public string MediaTypeHeaderValue => JsonCrafterConstants.Hal.MediaTypeHeaderValue;

        public JToken Convert(object obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
