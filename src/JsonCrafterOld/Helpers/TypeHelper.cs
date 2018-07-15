using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JsonCrafterOld.Settings;

namespace JsonCrafterOld.Helpers
{
    internal static class TypeHelper
    {
        internal static bool IsValue(Type type)
        {
            return IsString(type) || IsPrimitive(type);
        }

        internal static bool IsPrimitive(Type type)
        {
            return type.IsPrimitive;
        }

        internal static bool IsCollection(Type type)
        {
            return !IsString(type) && (type.IsArray || typeof(IEnumerable).IsAssignableFrom(type));
        }

        internal static bool IsBoolean(Type type)
        {
            return Type.GetTypeCode(type).Equals(TypeCode.Boolean);
        }

        internal static bool IsString(Type type)
        {
            return Type.GetTypeCode(type).Equals(TypeCode.String);
        }

        internal static bool IsNumeric(Type type)
        {
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;
                default:
                    return false;
            }
        }

        internal static  IEnumerable<MemberInfo> GetMembers(Type type)
        {
            return type.GetMembers(JsonCrafterConstants.Reflection.NonStaticPublicFlags)
                .Where(m => m.MemberType.Equals(MemberTypes.Field) || m.MemberType.Equals(MemberTypes.Property));
        }
    }
}
