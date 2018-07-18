using System;
using System.Linq.Expressions;

namespace JsonCrafter.Processing.Configuration.Settings
{
    public interface ILinkSettingBuilder<TResource> : IResourceBuilder<TResource> where TResource : class
    {
        /// <summary>
        /// Adds a parameter to a link object
        /// </summary>
        /// <typeparam name="TProp">The property type that represents the parameter</typeparam>
        /// <param name="key">The parameter key (that is searched for in the url template)</param>
        /// <param name="parameterExpression">The expression containg the resources property</param>
        /// <returns>The current linkbuilder</returns>
        ILinkSettingBuilder<TResource> WithParam<TProp>(string key, Expression<Func<TResource, TProp>> parameterExpression);
    }
}
