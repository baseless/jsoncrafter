using System;
using System.Collections.Generic;

namespace JsonCrafterOld.Reflection
{
    public interface IJsonCrafterReflectionService
    {
        IDictionary<Type, string> GetChildren(Type type);
    }
}
