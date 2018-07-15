using System;
using System.Reflection;
using JsonCrafterOld.Helpers;
using JsonCrafterOld.Serialization.Interfaces;

namespace JsonCrafterOld.Serialization
{
    public abstract class ResourceMemberBase<TInfo> : IResourceMember where TInfo: MemberInfo
    {
        protected TInfo Info { get; }
        public bool IsRelatedResource { get; }
        public bool IsValue { get; }
        public bool IsCollection { get; }

        protected ResourceMemberBase(string name, TInfo info, bool isResource, Type targetType)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Info = info ?? throw new ArgumentNullException(nameof(info));

            IsRelatedResource = isResource;
            IsValue = TypeHelper.IsValue(targetType);
            IsCollection = TypeHelper.IsCollection(targetType);
        }

        public abstract object GetValueFromObject(object obj);

        public string Name { get; }
    }
}
