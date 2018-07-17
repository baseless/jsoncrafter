namespace JsonCrafter.Processing.Serialization.Hal
{
    /// <summary>
    /// -- JSON HyperText Application Language (HAL)
    /// -- 'draft-kelly-json-hal-08'
    /// -- https://www.ietf.org/archive/id/draft-kelly-json-hal-08.txt
    /// 
    /// RULE - Root MUST be aresource object.
    /// RULE - '_links' and '_embedded' are reserved property names.
    /// 
    /// PATTERN (OPTIONAL) - HyperText Cache
    /// ----------------------------------
    /// This means that the server tries to replace resource links with embedded resources when possible (as to reduce number of round trips).
    /// JsonCrafters current strategi is to let the API developer decide which embedded resources to include,
    /// not trying to 'auto-magically' fatch and append data the developer has not intentionally included.
    ///
    /// REFERENCES
    /// ----------
    /// [RFC5988] - https://tools.ietf.org/html/rfc5988
    /// [RFC3986] - https://www.ietf.org/rfc/rfc3986.txt
    /// [RFC6570] - https://tools.ietf.org/html/rfc6570
    /// [I-D.wilde-profile-link] - https://tools.ietf.org/html/draft-wilde-profile-link-04
    /// [W3C.NOTE-curie-20101216] - https://www.w3.org/TR/2010/NOTE-curie-20101216
    /// </summary>
    public static class HalSpecification
    {
        public const string FormatName = "hal+json";
        public const string MediaTypeHeaderValue = "application/hal+json";

        /// <summary>
        /// RULE - ''
        /// </summary>
        public static class ResourceObject
        {
            /// <summary>
            /// OPTIONAL - Property names are link relation types [RFC5988], values are either link objects or array of link objects. Embedded url:s may be full or partial.
            /// </summary>
            public static class Embedded
            {
                public const string EmbeddedName = "_embedded";
            }

            /// <summary>
            /// OPTIONAL - Property names are link relation types [RFC5988], values are either link objects or array of link objects. Subject resource of these links is the parent resource object.
            ///
            /// I.E: The '_links'´object contain link properties. These either is formed as '"self": { "href": "/books/abc" }' OR "self": [ { "href": "/books/the-way-of-zen" } ].
            /// The link format is EITHER relative OR absolute.
            /// </summary>
            public static class Links
            {
                public const string LinksName = "_links";

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

                /// <summary>
                /// Commonly used link objects embedded in '_links'.
                /// Common link object names: last, first, next, prev as paging links for list resources
                /// </summary>
                public static class Types
                {
                    /// <summary>
                    /// RECOMMENDED - All resources should contain a link to self, [RFC5988]
                    /// </summary>
                    public const string LinkToSelf = "self"; // { "href": "/orders" } (for a collection resource)

                    /// <summary>
                    /// OPTIONAL - Link to find a resource object of this type by its id.
                    /// </summary>
                    public const string LinkToFind = "find"; // { "href": "/orders{?id}", "templated": true }
                }

                /// <summary>
                /// OPTIONAL - Embedded object in '_links', used to provide url templates in order to reduce the size of response (by not having to duplicate links.)
                ///
                /// The CURIE Syntax [W3C.NOTE-curie-20101216] MAY be used for brevity for these URIs.
                /// CURIEs are established within a HAL document via a set of Link Objects with the relation type "curies" on the root Resource Object.
                /// These links contain a URI Template with the token 'rel', and are named via the "name" property.
                ///
                /// Curies has name and href as all other links!
                /// 
                /// I.E: "_links": { "curies": [ { "name": "doc", "href": "http://docs/rel/{rel}" "templated": true } ] }
                /// </summary>
                public static class CuriesSubObject
                {
                    public const string CuriesSubObjectName = "curies";

                    /// <summary>
                    /// Should be inluded as true always? (cannot find definition for this curie property).
                    /// </summary>
                    public const string Templated = "templated";
                }
            }
        }
    }
}
