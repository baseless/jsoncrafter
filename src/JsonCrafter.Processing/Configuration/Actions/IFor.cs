namespace JsonCrafter.Processing.Configuration
{
    public interface IFor
    {
        /// <summary>
        /// Registers a new serialization-contract for a specific resource type.
        /// Also creates a new 'LinkToSelf' setting.
        /// </summary>
        /// <typeparam name="TResource">The type of the resource object.</typeparam>
        /// <param name="urlToSelf">The url template that should point to this resource object.</param>
        /// <param name="urlParameters">The url parameters needed to process the url template 'urlToSelf'.</param>
        /// <returns>The configurator for this type.</returns>
        IResourceBuilder<TResource> For<TResource>() where TResource : class;
    }
}
