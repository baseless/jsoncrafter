using System;
using System.Linq.Expressions;
using JsonCrafter.Configuration;
using JsonCrafter.Shared.Enums;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newtonsoft.Json.Serialization;

namespace JsonCrafter.Build
{
    public class JsonCrafterConfigurationBuilder : IJsonCrafterConfigurator, IJsonCrafterConfiguratorBuilder
    {
        public void EnableMediaType(JsonCrafterMediaType type)
        {
            throw new System.NotImplementedException();
        }

        public IResourceConfigurator<TResource> For<TResource>(string url, params Expression<Func<TResource, object>>[] values) where TResource : class
        {
            throw new NotImplementedException();
        }

        public IContractResolver Build(IActionContextAccessor actionContext, IJsonCrafterConfigurator configurator)
        {
            throw new System.NotImplementedException();
        }
    }
}
