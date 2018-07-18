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
        /// <param name="identifier">The expression containing the identifier resource member</param>
        /// <returns>The current resourcebuilder</returns>
        IResourceBuilder<TResource> HasId<TId>(Expression<Func<TResource, TId>> identifier);

        /// <summary>
        /// Provides a link template (kown as for example CURIE).
        /// NOTE: Not used by all HATEOAS formats (HAL uses it but not JsonAPI for example).
        /// </summary>
        /// <param name="name">The name of the link that will appear in the json response.</param>
        /// <param name="urlTemplate">The template url</param>
        /// <returns></returns>
        ILinkSettingBuilder<TResource> HasTemplate(string name, string urlTemplate);

        /// <summary>
        /// Adds a 'LinkToSelf' object to the Json response for the resource
        /// </summary>
        /// <param name="urlTemplate">The url template that will be used to resolve the resourcelink</param>
        /// <returns>The current linkbuilder</returns>
        ILinkSettingBuilder<TResource> HasLinkToSelf(string urlTemplate);

        /// <summary>
        /// Adds a 'LinkToNext' object to the Json response for the resource
        /// </summary>
        /// <param name="urlTemplate">The url template that will be used to resolve the resourcelink</param>
        /// <returns>The current linkbuilder</returns>
        ILinkSettingBuilder<TResource> HasLinkToNext(string urlTemplate);

        /// <summary>
        /// Adds a 'LinkToPrevious' object to the Json response for the resource
        /// </summary>
        /// <param name="urlTemplate">The url template that will be used to resolve the resourcelink</param>
        /// <returns>The current linkbuilder</returns>
        ILinkSettingBuilder<TResource> HasLinkToPrevious(string urlTemplate);

        /// <summary>
        /// Adds a 'LinkToFirst' object to the Json response for the resource
        /// </summary>
        /// <param name="urlTemplate">The url template that will be used to resolve the resourcelink</param>
        /// <returns>The current linkbuilder</returns>
        ILinkSettingBuilder<TResource> HasLinkToFirst(string urlTemplate);

        /// <summary>
        /// Adds a 'LinkToLast' object to the Json response for the resource
        /// </summary>
        /// <param name="urlTemplate">The url template that will be used to resolve the resourcelink</param>
        /// <returns>The current linkbuilder</returns>
        ILinkSettingBuilder<TResource> HasLinkToLast(string urlTemplate);

        /// <summary>
        /// Adds a 'Link' object to the Json response for the resource
        /// </summary>
        /// <param name="name">The name of the link that will appear in the json response.</param>
        /// <param name="urlTemplate">The url template that will be used to resolve the resourcelink</param>
        /// <returns>The current linkbuilder</returns>
        ILinkSettingBuilder<TResource> HasLink(string name, string urlTemplate);

        /// <summary>
        /// Specifies that the resource has an embedded / child resource that also should be processed.
        /// This could be a single object, or a collection, BUT it needs to be a valid resource type.
        /// </summary>
        /// <typeparam name="TEmbedded">The embedded members type</typeparam>
        /// <param name="embeddedResource">the expression containing the embedded types member</param>
        /// <returns>The current resourcebuilder</returns>
        IResourceBuilder<TResource> HasEmbedded<TEmbedded>(Expression<Func<TResource, TEmbedded>> embeddedResource);
    }
}
