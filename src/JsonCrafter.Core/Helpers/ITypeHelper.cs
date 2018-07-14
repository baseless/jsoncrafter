using System;
using System.Collections.Generic;
using System.Reflection;

namespace JsonCrafter.Core.Helpers
{
    public interface ITypeHelper
    {
        bool IsEnumerable(Type type);
        FieldInfo[] GetPublicFields(Type type);
        PropertyInfo[] GetPublicProperties(Type type);
        IEnumerable<MemberInfo> GetMembers(Type type);
    }
}
