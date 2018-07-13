using System;

namespace JsonCrafter.Core.TypeHelpers
{
    public interface ITypeHandler
    {
        bool IsEnumerable(Type type);
        bool IsReferenceType(Type type);
    }
}
