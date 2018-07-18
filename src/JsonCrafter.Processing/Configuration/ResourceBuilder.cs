using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using JsonCrafter.Core;
using JsonCrafter.Core.Enums;
using JsonCrafter.Core.Exceptions;
using JsonCrafter.Core.Helpers;
using JsonCrafter.Processing.Configuration.Settings;

namespace JsonCrafter.Processing.Configuration
{
    /// <summary>
    /// Assembles the configuration for one specific resource type.
    /// </summary>
    /// <typeparam name="TResource">The type of resource to be configured.</typeparam>
    public sealed class ResourceBuilder<TResource> : IResource, IResourceBuilder<TResource> where TResource: class
    {
        private readonly IConfigurationBuilder _parent;

        /// <summary>
        /// All settings for this resource type.
        /// </summary>
        public ICollection<IResourceSetting> Settings { get; } = new List<IResourceSetting>();

        public ResourceBuilder(IConfigurationBuilder parent, IResourceSetting setting = default(IResourceSetting))
        {
            _parent = Ensure.IsSet(parent);
            if (setting != default(IResourceSetting))
            {
                Settings.Add(setting);
            }
        }
        
        /// <inheritdoc />
        public ILinkSettingBuilder<TResource> HasTemplate(string name, string urlTemplate)
        {
            Ensure.IsSet(name, $"A name must be entered for the link with url '{urlTemplate}' for resource '{typeof(TResource).Name}'");

            return AddLinkSetting(LinkSettingsType.Template, name, urlTemplate);
        }

        /// <inheritdoc />
        public ILinkSettingBuilder<TResource> HasLinkToSelf(string urlTemplate)
        {
            return AddLinkSetting(LinkSettingsType.ToSelf, string.Empty, urlTemplate);
        }

        /// <inheritdoc />
        public ILinkSettingBuilder<TResource> HasLinkToNext(string urlTemplate)
        {
            return AddLinkSetting(LinkSettingsType.ToNext, string.Empty, urlTemplate);
        }

        /// <inheritdoc />
        public ILinkSettingBuilder<TResource> HasLinkToPrevious(string urlTemplate)
        {
            return AddLinkSetting(LinkSettingsType.ToPrevious, string.Empty, urlTemplate);
        }

        /// <inheritdoc />
        public ILinkSettingBuilder<TResource> HasLinkToFirst(string urlTemplate)
        {
            return AddLinkSetting(LinkSettingsType.ToFirst, string.Empty, urlTemplate);
        }

        /// <inheritdoc />
        public ILinkSettingBuilder<TResource> HasLinkToLast(string urlTemplate)
        {
            return AddLinkSetting(LinkSettingsType.ToLast, string.Empty, urlTemplate);
        }

        /// <inheritdoc />
        public ILinkSettingBuilder<TResource> HasLink(string name, string urlTemplate)
        {
            Ensure.IsSet(name, $"A name must be entered for the link with url '{urlTemplate}' for resource '{typeof(TResource).Name}'");

            return AddLinkSetting(LinkSettingsType.Custom, name, urlTemplate);
        }

        /// <inheritdoc />
        public IResourceBuilder<TResource> HasEmbedded<TEmbedded>(Expression<Func<TResource, TEmbedded>> embeddedResource)
        {
            Ensure.IsSet(embeddedResource);
            var summary = embeddedResource.GetMemberSummary();

            Ensure.IsSet(summary, $"Could not retrieve member identifier from expression recieved in 'HasEmbedded<>()' for resource of type '{typeof(TResource).Name}' (ensure a property or field was selected).");

            var embeddedSetting = new EmbeddedSettingBuilder<TResource>(_parent, this, summary);
            Settings.Add(embeddedSetting);
            return embeddedSetting;
        }

        /// <inheritdoc />
        public IResourceBuilder<TResource> HasId<TId>(Expression<Func<TResource, TId>> identifier)
        {
            Ensure.IsSet(identifier);

            var summary = identifier.GetMemberSummary();

            Ensure.IsSet(summary, $"Could not retrieve member identifier from expression recieved in 'HasId<>()' for resource of type '{typeof(TResource).Name}' (ensure a property or field was selected).");

            var idSetting = new IdentifierSettingBuilder<TResource>(_parent, this, summary);
            Settings.Add(idSetting);
            return idSetting;
        }

        private ILinkSettingBuilder<TResource> AddLinkSetting(LinkSettingsType type, string name, string urlTemplate)
        {
            Ensure.IsSet(urlTemplate, $"Url template must be set for the '{type.ToString()}' link with name '{name}' for resource '{typeof(TResource).Name}'");

            if (!urlTemplate.IsValidTemplateUrl())
            {
                throw new JsonCrafterException($"The entered url '{urlTemplate}' (for template with name '{name}') is not a valid url.");
            }

            var link = new LinkSettingBuilder<TResource>(_parent, this, type, name, urlTemplate);

            Settings.Add(link);
            return link;
        }

        #region Callbacks

        /// <inheritdoc />
        public IResourceBuilder<TNew> For<TNew>() where TNew : class => _parent.For<TNew>();

        #endregion
    }
}
