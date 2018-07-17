using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace JsonCrafter.Core.Helpers
{
    public static class TypeHelper
    {
        private const BindingFlags NonStaticPublicFlags = BindingFlags.Public | BindingFlags.Instance;

        public static bool IsClass(Type type)
        {
            return type.IsClass;
        }

        public static bool IsValue(Type type)
        {
            return IsString(type) || IsPrimitive(type);
        }

        public static bool IsPrimitive(Type type)
        {
            return type.IsPrimitive;
        }

        public static bool IsCollection(Type type)
        {
            return !IsString(type) && (type.IsArray || typeof(IEnumerable).IsAssignableFrom(type));
        }

        public static bool IsBoolean(Type type)
        {
            return Type.GetTypeCode(type).Equals(TypeCode.Boolean);
        }

        public static bool IsString(Type type)
        {
            return Type.GetTypeCode(type).Equals(TypeCode.String);
        }

        public static bool IsNumeric(Type type)
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

        public static  IEnumerable<MemberInfo> GetMembers(Type type)
        {
            return type.GetMembers(NonStaticPublicFlags)
                .Where(m => m.MemberType.Equals(MemberTypes.Field) || m.MemberType.Equals(MemberTypes.Property));
        }

        public static bool ContainOnlyValueTypes<TResource>(Expression<Func<TResource, Type>>[] typeExpressions, out Type failedType)
        {
            foreach (var body in typeExpressions)
            {
                if (TypeHelper.IsValue(body.Type)) continue;
                failedType = body.Type;
                return false;
            }

            failedType = null;
            return true;
        }
    }
}
