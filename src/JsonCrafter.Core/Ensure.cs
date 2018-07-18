using System;
using System.Linq.Expressions;
using JsonCrafter.Core.Exceptions;
using JsonCrafter.Core.Helpers;

namespace JsonCrafter.Core
{
    public static class Ensure
    {
        public static T IsSet<T>(T obj, string errorMessage = null) where T: class
        {
            IsNotNull(obj);

            if (obj == default(T))
            {
                throw new ArgumentException(errorMessage ?? typeof(T).FullName);
            }

            return obj;
        }

        public static T IsNotNull<T>(T obj, string errorMessage = null)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(errorMessage ?? typeof(T).FullName);
            }

            return obj;
        }
    }
}
