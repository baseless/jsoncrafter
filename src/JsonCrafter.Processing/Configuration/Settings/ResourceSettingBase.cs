using System;
using System.Linq.Expressions;
using JsonCrafter.Core;

namespace JsonCrafter.Processing.Configuration.Settings
{
    /// <summary>
    /// Base class for all resource settings definitions
    /// </summary>
    /// <typeparam name="TResource">The type of resource that the settingsinstance targets</typeparam>
    public class ResourceSettingBase<TResource> : IResourceBuilder<TResource> where TResource : class
    {
        protected readonly IConfigurationBuilder ParentBuilder;
        protected readonly IResourceBuilder<TResource> ParentResource;

        public ResourceSettingBase(IConfigurationBuilder parentBuilder, IResourceBuilder<TResource> parentResource)
        {
            ParentBuilder = Ensure.IsSet(parentBuilder);
            ParentResource = Ensure.IsSet(parentResource);
        }

        /// <inheritdoc />
        public IResourceBuilder<TNew> For<TNew>() where TNew : class 
            => ParentBuilder.For<TNew>();

        /// <inheritdoc />
        public IResourceBuilder<TResource> HasId<TId>(Expression<Func<TResource, TId>> identifier) 
            => ParentResource.HasId(identifier);

        /// <inheritdoc />
        public ILinkSettingBuilder<TResource> HasTemplate(string templateIdentifier, string url)
            => ParentResource.HasTemplate(templateIdentifier, url);

        /// <inheritdoc />
        public ILinkSettingBuilder<TResource> HasLinkToSelf(string urlTemplate) =>
            ParentResource.HasLinkToSelf(urlTemplate);

        /// <inheritdoc />
        public ILinkSettingBuilder<TResource> HasLinkToNext(string urlTemplate) =>
            ParentResource.HasLinkToNext(urlTemplate);

        /// <inheritdoc />
        public ILinkSettingBuilder<TResource> HasLinkToPrevious(string urlTemplate) =>
            ParentResource.HasLinkToPrevious(urlTemplate);

        /// <inheritdoc />
        public ILinkSettingBuilder<TResource> HasLinkToFirst(string urlTemplate) =>
            ParentResource.HasLinkToFirst(urlTemplate);

        /// <inheritdoc />
        public ILinkSettingBuilder<TResource> HasLinkToLast(string urlTemplate) =>
            ParentResource.HasLinkToLast(urlTemplate);

        /// <inheritdoc />
        public ILinkSettingBuilder<TResource> HasLink(string name, string urlTemplate) =>
            ParentResource.HasLink(name, urlTemplate);

        /// <inheritdoc />
        public IResourceBuilder<TResource> HasEmbedded<TEmbedded>(Expression<Func<TResource, TEmbedded>> embeddedResource) =>
            ParentResource.HasEmbedded(embeddedResource);
    }
}
