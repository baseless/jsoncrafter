using System;
using System.Reflection;

namespace JsonCrafter.Core.Info
{
    public sealed class PropertyValueInfo : IValueInfo
    {
        private readonly PropertyInfo _info;

        public PropertyValueInfo(PropertyInfo info)
        {
            _info = info;
        }

        public object GetValue(object obj) => _info.GetValue(obj);

        public Type MemberType => _info.PropertyType;

        public string Name => _info.Name;
    }
}
