using System.Reflection;

namespace JsonCrafter.Shared
{
    public static class JsonCrafterConstants
    {
        public static class Reflection
        {
            public const BindingFlags NonStaticPublicFlags = BindingFlags.Public | BindingFlags.Instance;
        }

        public static class Hal
        {
            public const string FormatName = "hal+json";
            public const string MediaTypeHeaderValue = "application/hal+json";
        }
    }
}
