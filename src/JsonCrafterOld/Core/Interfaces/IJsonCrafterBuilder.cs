using System;
using System.Linq.Expressions;
using JsonCrafterOld.Configuration.Interfaces;
using JsonCrafterOld.Settings;

namespace JsonCrafterOld.Core.Interfaces
{
    public interface IJsonCrafterBuilder
    {
        void EnableMediaType(JsonCrafterMediaType type);
        IResourceConfiguration<TResource> For<TResource>(string url, params Expression<Func<TResource, object>>[] values) where TResource : class;
    }
}
