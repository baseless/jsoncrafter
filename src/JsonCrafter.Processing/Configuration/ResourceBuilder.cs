using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using JsonCrafter.Core;
using JsonCrafter.Processing.Configuration.Settings;

namespace JsonCrafter.Processing.Configuration
{
    /// <summary>
    /// Assembles the configuration for one specific resource type.
    /// </summary>
    /// <typeparam name="TResource">The type of resource to be configured.</typeparam>
    public class ResourceBuilder<TResource> : IResourceConfiguration, IResourceBuilder<TResource> where TResource: class
    {
        private readonly IConfigurationBuilder _parent;

        /// <summary>
        /// All settings build for this resource type.
        /// </summary>
        public IDictionary<Type, ICollection<IResourceSetting>> Settings { get; } = new Dictionary<Type, ICollection<IResourceSetting>>();

        public ResourceBuilder(IConfigurationBuilder parent, IResourceSetting setting = default(IResourceSetting))
        {
            _parent = Ensure.IsSet(parent);

            if (setting != default(IResourceSetting) && !Settings.TryAdd(typeof(TResource), new List<IResourceSetting> { setting }))
            {
                Settings[typeof(TResource)].Add(setting);
            }
        }
        
        /// <inheritdoc />
        public IResourceBuilder<TNew> For<TNew>() where TNew : class => _parent.For<TNew>();

        /// <inheritdoc />
        public IResourceBuilder<TNew> For<TNew>(string urlToSelf, params Expression<Func<TNew, Type>>[] urlParameters) where TNew : class 
            => _parent.For(urlToSelf, urlParameters);

        /// <inheritdoc />
        public IResourceBuilder<TResource> HasId(params Expression<Func<TResource, Type>>[] idProperties)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public IResourceBuilder<TResource> HasTemplate(string templateIdentifier, string url, params Expression<Func<TResource, Type>>[] additionalParameters)
        {
            throw new NotImplementedException();
        }
    }
}
