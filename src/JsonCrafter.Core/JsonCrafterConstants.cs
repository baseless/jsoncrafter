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
            public const string Version = "draft-kelly-json-hal-08";
            public const string Specification = "https://www.ietf.org/archive/id/draft-kelly-json-hal-08.txt";

            public static class Properties
            {
                /// <summary>
                /// OPTIONAL - Property names are link relation types ([RFC5988]), values are either link objects or array of link objects. Embedded url:s may be full or partial.
                /// </summary>
                public static class EmbeddedObject
                {
                    /// <summary>
                    /// RESERVED propertyname
                    /// </summary>
                    public const string ObjectName = "_embedded";
                }
                
                /// <summary>
                /// OPTIONAL - Property names are link relation types ([RFC5988]), values are either link objects or array of link objects. Subject resource of these links is the parent resource object.
                /// </summary>
                public static class LinksObject
                {
                    /// <summary>
                    /// RESERVED propertyname
                    /// </summary>
                    public const string ObjectName = "_links";

                    /// <summary>
                    /// REQUIRED - Value is either URI [RFC3986] or URI template [RFC6570]
                    /// </summary>
                    public const string Href = "href";

                    /// <summary>
                    /// OPTIONAL - used as hint to indicate the mediatype expected when dereferencing target resource.
                    /// </summary>
                    public const string Type = "type";

                    /// <summary>
                    /// OPTIONAL - Notes if link is about to be deprecated at future date. Contains URL that should provide further information about the deprecation.
                    /// </summary>
                    public const string Deprecation = "deprecation";

                    /// <summary>
                    /// OPTIONAL - MAY be used as a secondary key for selecting link objects which cshare the same relation type.
                    /// </summary>
                    public const string Name = "name";

                    /// <summary>
                    /// OPTIONAL - A string which is a URI that hints about the profile [I-D.wilde-profile-link] of the target resource.
                    /// </summary>
                    public const string Profile = "profile";

                    /// <summary>
                    /// OPTIONAL - String intended for labelling the link with a human-readable identifier [RFC5988].
                    /// </summary>
                    public const string Title = "title";

                    /// <summary>
                    /// OPTIONAL - For indicating the language of the target resource [RFC5988]
                    /// </summary>
                    public const string HrefLang = "hreflang";
                }
                public const string LinkToSelf = "self";
                public const string LinkToNext = "next";
                public const string LinkToPrevious = "prev";
                public const string LinkToLast = "last";
            }
        }
    }
}
