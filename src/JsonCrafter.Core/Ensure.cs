using System;
using System.Linq.Expressions;
using JsonCrafter.Core.Exceptions;
using JsonCrafter.Core.Helpers;

namespace JsonCrafter.Core
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

            if (!objType.IsClass)
            {
                throw new JsonCrafterException($"Recieved object was not a valid resource object (must be class, recieved type was '{objType.FullName}')");
            }

            return obj;
        }

        public static Expression<Func<TResource, Type>> IsValidUrlParameterType<TResource>(Expression<Func<TResource, Type>> expression)
        {
            IsSet(expression);
            
            if (!expression.Body.Type.IsValidUrlParameterType())
            {
                throw new JsonCrafterException($"'{expression.Body.Type.Name}' is not a valid parameter type (only strings and primitive types are allowed).");
            }

            return expression;
        }

        public static Expression<Func<TResource, Type>>[] ContainsOnlyValidParameterTypes<TResource>(Expression<Func<TResource, Type>>[] valuesExpressions)
        {
            IsSet(valuesExpressions);

            foreach (var exp in valuesExpressions)
            {
                IsValidUrlParameterType(exp);
            }

            return valuesExpressions;
        }
    }
}
