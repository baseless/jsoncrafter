using System;
using System.Collections;

namespace JsonCrafter.Core.Handlers
{
    public class TypeHandler : ITypeHandler
    {
        public bool IsEnumerable(Type type)
        {
            return typeof(IEnumerable).IsAssignableFrom(type);
        }
    }
}
