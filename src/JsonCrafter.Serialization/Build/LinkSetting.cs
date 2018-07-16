using System;
using System.Linq.Expressions;
using JsonCrafter.Shared;
using JsonCrafter.Shared.Enums;
using Microsoft.AspNetCore.Mvc;

namespace JsonCrafter.Serialization.Build
{
    public enum LinkSettingsType
    {
        ToSelf
    }

    public class LinkSetting<TResource> : IResourceSetting
    {
        private Expression<Func<IUrlHelper, string>> _url; 
        private Expression<Func<TResource, object>>[] _values;
        private readonly string _name;

        public LinkSettingsType LinkType { get; }
        public ResourceSettingsType SettingsType { get; } = ResourceSettingsType.Link;
        public Type MemberType { get; }

        public LinkSetting(Type memberType, LinkSettingsType linkType, string name, Expression<Func<IUrlHelper, string>> url, params Expression<Func<TResource, object>>[] values)
        {
            MemberType = Ensure.IsSet(memberType);
            LinkType = linkType;
            _url = Ensure.IsSet(url);
            _values = Ensure.IsSet(values);
            _name = name ?? string.Empty;
        }
    }
}
