using JsonCrafter.Core.Configuration;
using JsonCrafter.Demo.Api.Model;

namespace JsonCrafter.Demo.Api.Configuration
{
    public class HyperMediaConfiguration : IJsonCrafterConfiguration
    {
        public void Configure(IJsonCrafterBuilder builder)
        {
            builder.EnableMediaType(MediaType.Hal);

            builder.For<User>();
        }
    }
}
