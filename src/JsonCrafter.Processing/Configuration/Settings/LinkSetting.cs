using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using JsonCrafter.Core;
using JsonCrafter.Core.Enums;
using JsonCrafter.Core.Exceptions;

namespace JsonCrafter.Processing.Configuration.Settings
{
    public enum LinkSettingsType
    {
        ToSelf,
        Custom
    }

    public class LinkSettings<TResource> : ILinkSetting<TResource>, IResourceSetting where TResource: class
    {
        private readonly IResourceBuilder<TResource> _parentResourceBuilder;
        private readonly IConfigurationBuilder _parentConfigBuilder;

        private readonly string _url; 
        private readonly string _name;
        private readonly IDictionary<string, Expression<Func<TResource, Type>>> _parameters = new Dictionary<string, Expression<Func<TResource, Type>>>();

        public LinkSettingsType LinkType { get; }
        public ResourceSettingsType SettingsType { get; } = ResourceSettingsType.Link;
        public Type MemberType { get; }

        public LinkSettings(IResourceBuilder<TResource>  parent, Type memberType, LinkSettingsType linkType, string name, string url)
        {
            _parentResourceBuilder = Ensure.IsSet(parent);
            MemberType = Ensure.IsSet(memberType);
            _url = Ensure.IsSet(url);
            LinkType = linkType;
            _name = name ?? string.Empty;
        }

        public ILinkSetting<TResource> WithParam(string key, Expression<Func<TResource, Type>> parameterExpression)
        {
            Ensure.IsSet(key);
            Ensure.IsSet(parameterExpression);

            if (_parameters.ContainsKey(key))
            {
                throw new JsonCrafterException($"Adding the same key ({key}) for same link ({_url}) for same type ({MemberType.Name}) twice is not allowed.");
            }

            _parameters.Add(key, parameterExpression);

            return this;
        }

        #region Callbacks



        #endregion
    }
}
