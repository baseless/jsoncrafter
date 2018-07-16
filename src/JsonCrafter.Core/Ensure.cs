using System;

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
    }
}
