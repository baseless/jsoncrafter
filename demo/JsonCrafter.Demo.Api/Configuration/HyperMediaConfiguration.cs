using JsonCrafter.Core.Configuration;
using JsonCrafter.Demo.Api.Controllers;

namespace JsonCrafter.Demo.Api.Configuration
{
    public class HyperMediaConfiguration : IJsonCrafterConfiguration
    {
        public void Configure(IJsonCrafterBuilder builder)
        {
            builder.EnableMediaType(MediaType.Hal);

            builder.For<Test>()
                .HasLinkToSelf("http://baba/users/{0}", t => t.Id)
                .HasRelatedResource(r => r.TestTests);
        }
    }
}
