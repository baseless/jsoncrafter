using System;
using System.Linq.Expressions;
using JsonCrafter.Processing.Configuration.Settings;

namespace JsonCrafter.Processing.Configuration
{
    public interface IResourceBuilder<TResource> : IFor where TResource : class
    {
        /// <summary>
        /// Configures the id for this resource.
        /// NOTE: Not used by all HATEOAS formats (JsonAPI uses if but not HAL for example).
        /// </summary>
        /// <param name="idProperties"></param>
        /// <returns></returns>
        IResourceBuilder<TResource> HasId(params Expression<Func<TResource, Type>>[] idProperties);

        /// <summary>
        /// Provides a link template (kown as for example CURIE).
        /// NOTE: Not used by all HATEOAS formats (HAL uses it but not JsonAPI for example).
        /// </summary>
        /// <param name="name"></param>
        /// <param name="url">The template url</param>
        /// <returns></returns>
        ILinkSettingBuilder<TResource> HasTemplate(string name, string url);

        //ITypeBuilder<T> HasLinkToSelf(string url, params string[] values);
        //ITypeBuilder<T> HasLinkToSelf(string url, params Func<T, object>[] values);
        //ITypeBuilder<T> HasLink(string name, string templateId, string url, params Func<T, object>[] values);
        //ITypeBuilder<T> HasLink(string name, string templateId, string url, params string[] values);
        //IResourceConfiguraton<TResource> ContainsResource(Expression<Func<TResource, object>> resource);
    }
}
