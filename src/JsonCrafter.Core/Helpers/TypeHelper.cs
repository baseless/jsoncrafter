using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace JsonCrafter.Core.Helpers
{
    public class TypeHelper : ITypeHelper
    {
        private static BindingFlags _nonStaticPublicFlags = BindingFlags.Public | BindingFlags.Instance;

        public bool IsEnumerable(Type type)
        {
            return typeof(IEnumerable).IsAssignableFrom(type);
        }

        public FieldInfo[] GetPublicFields(Type type)
        {
            return type.GetFields(_nonStaticPublicFlags);
        }

        public PropertyInfo[] GetPublicProperties(Type type)
        {
            return type.GetProperties(_nonStaticPublicFlags);
        }

        public IEnumerable<MemberInfo> GetMembers(Type type)
        {
            return type.GetMembers(_nonStaticPublicFlags)
                .Where(m => m.MemberType.Equals(MemberTypes.Field) || m.MemberType.Equals(MemberTypes.Property));
        }
    }
}
