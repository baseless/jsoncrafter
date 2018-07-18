using System;
using System.Linq.Expressions;

namespace JsonCrafter.Processing.Configuration.Settings
{
    public interface ILinkSettingBuilder<TResource> : IResourceBuilder<TResource> where TResource : class
    {
        ILinkSettingBuilder<TResource> WithParam<TProp>(string key, Expression<Func<TResource, TProp>> exp);
    }
}
