using System;
using System.Linq.Expressions;
using JsonCrafter.Core.Enums;

namespace JsonCrafter.Processing.Configuration
{
    public interface IConfigurationBuilder
    {
        /// <summary>
        /// Sets what casing should be used by JsonCrafter.
        ///
        /// CamelCase => 'camelCase' (default)
        /// PascalCase => 'PascalCase'
        /// SnakeCase => 'snake_case'
        /// ParamCase => 'param-case'
        /// </summary>
        /// <param name="format">The desired casing format.</param>
        void SetCasing(JsonCrafterCasing format);

        /// <summary>
        /// Enables JSON processing for a supported format.
        /// </summary>
        /// <param name="type">The format that is intended to be enabled.</param>
        void EnableMediaType(JsonCrafterMediaType type);

        /// <summary>
        /// Registers a new serialization-contract for a specific resource type.
        /// </summary>
        /// <typeparam name="TResource">The type of the resource object.</typeparam>
        /// <returns>The configurator for this type.</returns>
        IResourceBuilder<TResource> For<TResource>() where TResource : class;

        /// <summary>
        /// Registers a new serialization-contract for a specific resource type.
        /// Also creates a new 'LinkToSelf' setting.
        /// </summary>
        /// <typeparam name="TResource">The type of the resource object.</typeparam>
        /// <param name="urlToSelf">The url template that should point to this resource object.</param>
        /// <param name="urlParameters">The url parameters needed to process the url template 'urlToSelf'.</param>
        /// <returns>The configurator for this type.</returns>
        IResourceBuilder<TResource> For<TResource>(string urlToSelf, Expression<Func<TResource, Type>>[] urlParameters) where TResource : class;
    }
}
