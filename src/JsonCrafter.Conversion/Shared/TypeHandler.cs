using System;
using System.Collections;

namespace JsonCrafter.Conversion.Shared
{
    public class TypeHandler : ITypeHandler
    {
        public bool IsEnumerable(Type type)
        {
            return typeof(IEnumerable).IsAssignableFrom(type);
        }
    }
}
