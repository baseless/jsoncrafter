using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using JsonCrafter.Core;
using JsonCrafter.Core.Enums;
using JsonCrafter.Core.Exceptions;
using JsonCrafter.Core.Helpers;
using JsonCrafter.Core.Summary;

namespace JsonCrafter.Processing.Configuration.Settings
{
    /// <summary>
    /// Specifies a link object for a specific resource
    /// </summary>
    /// <typeparam name="TResource">The type of resource this setting applies to</typeparam>
    public class LinkSettingBuilder<TResource> : ResourceSettingBase<TResource>, ILinkSettingBuilder<TResource>, IResourceSetting where TResource: class
    {
        private readonly string _url; 
        private readonly string _name;
        private readonly IDictionary<string, IMemberSummary> _parameters = new Dictionary<string, IMemberSummary>();

        public LinkSettingsType LinkType { get; }
        public ResourceSettingsType SettingsType { get; } = ResourceSettingsType.Link;

        public LinkSettingBuilder(IConfigurationBuilder parentConfigBuilder, IResourceBuilder<TResource> parentResourceBuilder, LinkSettingsType linkType, string name, string url) : base(parentConfigBuilder, parentResourceBuilder)
        {
            _url = Ensure.IsSet(url);
            LinkType = linkType;
            _name = name ?? string.Empty;
        }

        public ILinkSettingBuilder<TResource> WithParam<TProp>(string key, Expression<Func<TResource, TProp>> parameterExpression)
        {
            Ensure.IsSet(key);
            Ensure.IsSet(parameterExpression);

            if (!typeof(TProp).IsValidUrlParameterType())
            {
                throw new JsonCrafterException($"The parameter '{typeof(TProp)}' is not a valid link-parameter type (only strings and primitive types allowed since they will be parsed into strings).");
            }

            if (_parameters.ContainsKey(key))
            {
                throw new JsonCrafterException($"Adding the same parameter-key ({key}) for same link ({_url}), for same resource, twice is not allowed. Ensure that 'WithParam(\"{key}\", \"..\")' is set only once for link '{_name}'");
            }

            var summary = parameterExpression.GetMemberSummary();
            
            _parameters.Add(new KeyValuePair<string, IMemberSummary>(key, summary));

            return this;
        }
    }
}