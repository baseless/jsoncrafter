using System;
using System.Linq.Expressions;
using JsonCrafter.Shared.Exceptions;
using JsonCrafter.Shared.Helpers;

namespace JsonCrafter.Shared
{
    public static class Ensure
    {
        public static T IsSet<T>(T obj) where T: class
        {
            IsNotNull(obj);

            if (obj == default(T))
            {
                throw new ArgumentException(typeof(T).FullName);
            }

            return obj;
        }

        public static T IsNotNull<T>(T obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(typeof(T).FullName);
            }

            return obj;
        }

        public static object IsValidResource(Type objType, object obj)
        {
            IsSet(obj);
            IsSet(objType);

            if (!TypeHelper.IsClass(objType))
            {
                throw new JsonCrafterException($"Recieved object was not a valid resource object (must be class, recieved type was '{objType.FullName}')");
            }

            return obj;
        }

        public static Expression<Func<TResource, Type>>[] ContainsOnlyValidParameterTypes<TResource>(Expression<Func<TResource, Type>>[] values)
        {
            IsSet(values);

            if (!TypeHelper.ContainOnlyValueTypes(values, out var failedType))
            {
                throw new JsonCrafterException($"'{failedType.Name}' is not a valid parameter type (only strings and primitive types are allowed).");
            }

            return values;
        }
    }
}
