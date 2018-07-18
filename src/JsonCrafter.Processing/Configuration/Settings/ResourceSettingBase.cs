using System;
using System.Linq.Expressions;
using JsonCrafter.Core;

namespace JsonCrafter.Processing.Configuration.Settings
{
    public class ResourceSettingBase<TResource> : IResourceBuilder<TResource> where TResource : class
    {
        protected readonly IConfigurationBuilder ParentBuilder;
        protected readonly IResourceBuilder<TResource> ParentResource;

        public ResourceSettingBase(IConfigurationBuilder parentBuilder, IResourceBuilder<TResource> parentResource)
        {
            ParentBuilder = Ensure.IsSet(parentBuilder);
            ParentResource = Ensure.IsSet(parentResource);
        }

        public IResourceBuilder<TNew> For<TNew>() where TNew : class 
            => ParentBuilder.For<TNew>();

        public IResourceBuilder<TResource> HasId(params Expression<Func<TResource, Type>>[] idProperties) 
            => ParentResource.HasId(idProperties);

        public ILinkSettingBuilder<TResource> HasTemplate(string templateIdentifier, string url)
            => ParentResource.HasTemplate(templateIdentifier, url);
    }
}
