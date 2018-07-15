using System.Reflection;

namespace JsonCrafterOld.Settings
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

            public static class Templates
            {
                public const string Root = "{ 'jsonCrafterVersion': '0.0.1-alpha1' }";
                public const string Object = "{}";
            }
        }
    }
}
