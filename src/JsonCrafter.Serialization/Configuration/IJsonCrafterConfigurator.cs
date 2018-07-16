using System;
using System.Linq.Expressions;
using JsonCrafter.Serialization.Build;
using JsonCrafter.Shared.Enums;
using Microsoft.AspNetCore.Mvc;

namespace JsonCrafter.Serialization.Configuration
{
    public interface IJsonCrafterConfigurator
    {
        void EnableMediaType(JsonCrafterMediaType type);
        IResourceConfigurator<TResource> For<TResource>(string url, Expression<Func<TResource, Type>>[] values) where TResource : class;
    }
}
