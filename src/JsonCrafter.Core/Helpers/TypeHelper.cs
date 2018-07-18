using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using JsonCrafter.Core.Summary;

namespace JsonCrafter.Core.Helpers
{
    public static class TypeHelper
    {
        private const BindingFlags NonStaticPublicFlags = BindingFlags.Public | BindingFlags.Instance;

        /// <summary>
        /// Checks if the specified type is an allowed resourceobject type.
        /// </summary>
        /// <param name="type">The type to validate.</param>
        /// <returns>True or false wether or not the typs is valid.</returns>
        public static bool IsValidResourceType(this Type type) => type.IsClass;

        /// <summary>
        /// Checks if the specified type is an allowed urlparameter type.
        /// </summary>
        /// <param name="type">The type to validate.</param>
        /// <returns>True or false wether or not the typs is valid.</returns>
        public static bool IsValidUrlParameterType(this Type type) => IsStringOrValue(type);

        /// <summary>
        /// Checks if the provided type is a string or any form of primitive / numeric type.
        /// Checks if it is string, primitive or decimal.
        /// </summary>
        /// <param name="type">The type to evaluate.</param>
        /// <returns>True or false whether or not the type was a string, primitive or decimal.</returns>
        public static bool IsStringOrValue(this Type type)
        {
            return type.IsString() || type.IsPrimitive || type.IsDecimal();
        }

        /// <summary>
        /// Checks if the provided type is a collection OR array.
        /// </summary>
        /// <param name="type">The type to evaluate.</param>
        /// <returns>True or false whether or not the type was a collection or array.</returns>
        public static bool IsAnyCollection(this Type type)
        {
            return !type.IsString() && (type.IsArray || typeof(IEnumerable).IsAssignableFrom(type));
        }
        
        /// <summary>
        /// Checks if the provided type is a string.
        /// </summary>
        /// <param name="type">The type to evaluate.</param>
        /// <returns>True or false whether or not the type was a string.</returns>
        public static bool IsString(this Type type)
        {
            return Type.GetTypeCode(type).Equals(TypeCode.String);
        }

        /// <summary>
        /// Checks if the provided type is a decimal type.
        /// </summary>
        /// <param name="type">The type to evaluate.</param>
        /// <returns>True or false whether or not the type was decimal.</returns>
        public static bool IsDecimal(this Type type)
        {
            return Type.GetTypeCode(type).Equals(TypeCode.Decimal);
        }

        /// <summary>
        /// Checks if the provided type is a numeric type.
        /// Note: All types resides as primitives except for decimal.
        /// </summary>
        /// <param name="type">The type to evaluate.</param>
        /// <returns>True or false whether or not the type was numeric.</returns>
        public static bool IsNumeric(this Type type) // in practise these are containd in primitive + decimal
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

        /// <summary>
        /// Gets all public fields and properties from a specific type.
        /// </summary>
        /// <param name="type">The type to extract members from.</param>
        /// <returns>A list of all public properties and fields.</returns>
        public static  IEnumerable<MemberInfo> GetMembers(this Type type)
        {
            return type.GetMembers(NonStaticPublicFlags)
                .Where(m => m.MemberType.Equals(MemberTypes.Field) || m.MemberType.Equals(MemberTypes.Property));
        }

        /// <summary>
        /// Extracts the fieldinfo or propertyinfo from an expression target (depending on the expression bodies type).
        /// </summary>
        /// <typeparam name="T">The type to generate the expression from.</typeparam>
        /// <typeparam name="TMember">The member specified in the method call.</typeparam>
        /// <param name="expr">The complete expression from the method call.</param>
        /// <returns>A facade containing the fieldinfo or propertyinfo (depending on the type of the TMember).</returns>
        public static IMemberSummary GetMemberSummary<T, TMember>(this Expression<Func<T, TMember>> expr)
        {
            if (expr.Body is MemberExpression member)
            {
                if (member.Member is PropertyInfo propInfo)
                {
                    return new PropertySummary(propInfo);
                }

                if (member.Member is FieldInfo fieldInfo)
                {
                    return new FieldSummary(fieldInfo);
                }
            }

            return null;
        }
    }
}
