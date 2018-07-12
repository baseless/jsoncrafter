using System.Collections;
using System.Collections.Generic;
using JsonCrafter.Appendices;
using JsonCrafter.Demo.Api.Model;

namespace JsonCrafter.Demo.Api.Configuration
{
    public sealed class JsonConfiguration : JsonCrafterConfigurationBase
    {
        public JsonConfiguration() : base(new HashSet<string> { JsonCrafterConstants.Hal.MediaTypeHeaderValue })
        {
            
        }

        public override void Configure(IAppendixBuilder builder)
        {
            builder.For<User>().LinkToSelf("http://users/{0}", o => o.Id.ToString());
        }
    }
}
