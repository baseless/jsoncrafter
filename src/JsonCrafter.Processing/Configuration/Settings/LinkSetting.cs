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
    public enum LinkSettingsType
    {
        ToSelf,
        Template,
        Custom
    }

    public class LinkSetting<TResource> : ResourceSettingBase<TResource>, ILinkSettingBuilder<TResource>, IResourceSettingConfiguration where TResource: class
    {
        private readonly string _url; 
        private readonly string _name;
        private readonly IDictionary<string, IMemberSummary> _parameters = new Dictionary<string, IMemberSummary>();

        public LinkSettingsType LinkType { get; }
        public ResourceSettingsType SettingsType { get; } = ResourceSettingsType.Link;

        public LinkSetting(IConfigurationBuilder parentConfigBuilder, IResourceBuilder<TResource> parentResourceBuilder, LinkSettingsType linkType, string name, string url) : base(parentConfigBuilder, parentResourceBuilder)
        {
            _url = Ensure.IsSet(url);
            LinkType = linkType;
            _name = name ?? string.Empty;
        }

        public ILinkSettingBuilder<TResource> WithParam<TProp>(string key, Expression<Func<TResource, TProp>> exp) // https://stackoverflow.com/questions/671968/retrieving-property-name-from-lambda-expression
        {
            Ensure.IsSet(key);
            Ensure.IsSet(exp);

            var summary = exp.GetMemberSummary(); // todo: check if membersummary is null => throw exception that expression is invalid
            
            if (_parameters.ContainsKey(key))
            {
                throw new JsonCrafterException($"Adding the same key ({key}) for same link ({_url}) for same resource twice is not allowed.");
            }

            _parameters.Add(new KeyValuePair<string, IMemberSummary>(key, summary));

            return this;
        }
    }
}