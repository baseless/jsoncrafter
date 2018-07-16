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
                /// OPTIONAL - Property names are link relation types ([RFC5988]), values are either link objects or array of link objects. Subject resource of these links is the parent resource object.
                public const string Reserved_Links = "_links"; 

                /// OPTIONAL - Property names are link relation types ([RFC5988]), values are either link objects or array of link objects. Embedded url:s may be full or partial.
                public const string Reserved_Embedded = "_embedded";

                /// Represents hyperlink from the containing resource to a URI.
                public static class LinkObjects
                {
                    /// REQUIRED - Value is either URI [RFC3986] or URI template [RFC6570]
                    public const string Href = "href";

                    /// OPTIONAL - used as hint to indicate the mediatype expected when dereferencing target resource.
                    public const string Type = "type";

                    /// OPTIONAL - Notes if link is about to be deprecated at future date. Contains URL that should provide further information about the deprecation.
                    public const string Deprecation = "deprecation";

                    /// <summary>
                    /// OPTIONAL - MAY be used as a secondary key for selecting link objects which cshare the same relation type.
                    /// </summary>
                    public const string Name = "name";
                }
                public const string LinkToSelf = "self";
                public const string LinkToNext = "next";
                public const string LinkToPrevious = "prev";
                public const string LinkToLast = "last";
            }
        }
    }
}
