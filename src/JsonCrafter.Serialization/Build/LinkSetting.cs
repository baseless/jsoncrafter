using System;
using System.Linq.Expressions;
using JsonCrafter.Shared;
using JsonCrafter.Shared.Enums;

namespace JsonCrafter.Serialization.Build
{
    public enum LinkSettingsType
    {
        ToSelf
    }

    public class LinkSetting<TResource> : IResourceSetting
    {
        private readonly string _url; 
        private readonly Expression<Func<TResource, Type>>[] _values;
        private readonly string _name;

        public LinkSettingsType LinkType { get; }
        public ResourceSettingsType SettingsType { get; } = ResourceSettingsType.Link;
        public Type MemberType { get; }

        public LinkSetting(Type memberType, LinkSettingsType linkType, string name, string url, params Expression<Func<TResource, Type>>[] values)
        {
            MemberType = Ensure.IsSet(memberType);
            LinkType = linkType;
            _url = Ensure.IsSet(url);
            _values = Ensure.ContainsOnlyValidParameterTypes(values);
            _name = name ?? string.Empty;
            
        }
    }
}
