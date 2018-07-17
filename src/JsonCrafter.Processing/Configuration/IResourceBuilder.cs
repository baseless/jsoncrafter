using System;
using System.Linq.Expressions;

namespace JsonCrafter.Processing.Configuration
{
    public interface IResourceBuilder<TResource> where TResource : class
    {
        /// <summary>
        /// Registers a new serialization-contract for a specific resource type.
        /// </summary>
        /// <typeparam name="TNew">The type of the resource object.</typeparam>
        /// <returns>The configurator for this type.</returns>
        IResourceBuilder<TNew> For<TNew>() where TNew : class;

        /// <summary>
        /// Registers a new serialization-contract for a specific resource type.
        /// Also creates a new 'LinkToSelf' setting.
        /// </summary>
        /// <typeparam name="TNew">The type of the resource object.</typeparam>
        /// <param name="urlToSelf">The url template that should point to this resource object.</param>
        /// <param name="urlParameters">The url parameters needed to process the url template 'urlToSelf'.</param>
        /// <returns>The configurator for this type.</returns>
        IResourceBuilder<TNew> For<TNew>(string urlToSelf, params Expression<Func<TNew, Type>>[] urlParameters) where TNew : class;

        /// <summary>
        /// Configures the id for this resource.
        /// NOTE: Not used by all HATEOAS formats (JsonAPI uses if but not HAL for example).
        /// </summary>
        /// <param name="idParameters"></param>
        /// <returns></returns>
        IResourceBuilder<TResource> HasId(params Expression<Func<TResource, Type>>[] idProperties);

        /// <summary>
        /// Provides a link template (kown as for example CURIE).
        /// NOTE: Not used by all HATEOAS formats (HAL uses it but not JsonAPI for example).
        /// </summary>
        /// <param name="url">The template url</param>
        /// <param name="templateIdentifier"></param>
        /// <returns></returns>
        IResourceBuilder<TResource> HasTemplate(string templateIdentifier, string url, params Expression<Func<TResource, Type>>[] additionalParameters);

        //ITypeBuilder<T> HasLinkToSelf(string url, params string[] values);
        //ITypeBuilder<T> HasLinkToSelf(string url, params Func<T, object>[] values);
        //ITypeBuilder<T> HasLink(string name, string templateId, string url, params Func<T, object>[] values);
        //ITypeBuilder<T> HasLink(string name, string templateId, string url, params string[] values);
        //IResourceConfiguraton<TResource> ContainsResource(Expression<Func<TResource, object>> resource);
    }
}
