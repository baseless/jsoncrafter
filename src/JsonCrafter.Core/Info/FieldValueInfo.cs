using System;
using System.Reflection;

namespace JsonCrafter.Core.Info
{
    public sealed class FieldValueInfo : IValueInfo
    {
        private readonly FieldInfo _info;

        public FieldValueInfo(FieldInfo info)
        {
            _info = info;
        }

        public object GetValue(object obj) => _info.GetValue(obj);

        public Type MemberType => _info.FieldType;

        public string Name => _info.Name;
    }
}
