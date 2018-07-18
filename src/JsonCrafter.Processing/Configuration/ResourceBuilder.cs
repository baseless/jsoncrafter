using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using JsonCrafter.Core;
using JsonCrafter.Core.Exceptions;
using JsonCrafter.Core.Helpers;
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
        public IDictionary<Type, ICollection<IResourceSettingConfiguration>> Settings { get; } = new Dictionary<Type, ICollection<IResourceSettingConfiguration>>();

        public ResourceBuilder(IConfigurationBuilder parent, IResourceSettingConfiguration setting = default(IResourceSettingConfiguration))
        {
            _parent = Ensure.IsSet(parent);

            if (setting != default(IResourceSettingConfiguration) && !Settings.TryAdd(typeof(TResource), new List<IResourceSettingConfiguration> { setting }))
            {
                Settings[typeof(TResource)].Add(setting);
            }
        }
        
        /// <inheritdoc />
        public IResourceBuilder<TNew> For<TNew>() where TNew : class => _parent.For<TNew>();

        /// <inheritdoc />
        public IResourceBuilder<TResource> HasId(params Expression<Func<TResource, Type>>[] idProperties)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public ILinkSettingBuilder<TResource> HasTemplate(string name, string url)
        {
            if (!url.IsValidTemplateUrl())
            {
                throw new JsonCrafterException($"The entered url '{url}' (for template with name '{name}') is not valid.");
            }


            return new LinkSetting<TResource>(_parent, this, LinkSettingsType.Template, name, url);
        }
    }
}
