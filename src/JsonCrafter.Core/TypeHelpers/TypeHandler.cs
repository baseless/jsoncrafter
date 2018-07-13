using System;
using System.Collections;

namespace JsonCrafter.Core.TypeHelpers
{
    public class TypeHandler : ITypeHandler
    {
        public bool IsEnumerable(Type type)
        {
            return typeof(IEnumerable).IsAssignableFrom(type);
        }

        public bool IsReferenceType(Type type)
        {
            return false;
        }
    }
}
