using System;

namespace JsonCrafter.Conversion.Shared
{
    public interface ITypeHandler
    {
        bool IsEnumerable(Type type);
    }
}
