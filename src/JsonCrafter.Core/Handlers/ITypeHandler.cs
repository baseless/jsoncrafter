using System;

namespace JsonCrafter.Core.Handlers
{
    public interface ITypeHandler
    {
        bool IsEnumerable(Type type);
    }
}
