using System;
using System.Collections.Generic;

namespace JsonCrafter.Reflection
{
    public interface IJsonCrafterReflectionService
    {
        IDictionary<Type, string> GetChildren(Type type);
    }
}
