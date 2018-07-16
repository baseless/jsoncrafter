using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using JsonCrafter.Configuration;
using JsonCrafter.Shared;
using Microsoft.AspNetCore.Mvc;

namespace JsonCrafter.Build
{
    public class ResourceConfigurator<TResource> : IResourceBuilder, IResourceConfigurator<TResource> where TResource: class
    {
        private readonly IJsonCrafterConfigurator _parent;
        public IDictionary<Type, ICollection<IResourceSetting>> Settings { get; } = new Dictionary<Type, ICollection<IResourceSetting>>();

        public ResourceConfigurator(IJsonCrafterConfigurator parent, IResourceSetting setting = default(IResourceSetting))
        {
            _parent = Ensure.IsSet(parent);

            if (setting != default(IResourceSetting) && !Settings.TryAdd(typeof(TResource), new List<IResourceSetting> { setting }))
            {
                Settings[typeof(TResource)].Add(setting);
            }
        }

        public IResourceConfigurator<TResource> ContainsResource(Expression<Func<TResource, object>> resource)
        {
            throw new NotImplementedException();
        }

        public IResourceConfigurator<TNew> For<TNew>(Expression<Func<IUrlHelper, string>> url, params Expression<Func<TNew, object>>[] values) where TNew : class 
            => _parent.For(url, values);
    }
}
