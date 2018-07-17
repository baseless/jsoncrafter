namespace JsonCrafter.Serialization.Converters.JsonApi
{
    /// <summary>
    /// -- JSON:API
    /// -- 'v1.0'
    /// -- http://jsonapi.org/format/
    ///
    /// This section describes the structure of a JSON API document, which is identified by the media type application/vnd.api+json. JSON API documents are defined in JavaScript Object Notation (JSON) [RFC7159].
    /// Although the same media type is used for both request and response documents, certain aspects are only applicable to one or the other. These differences are called out below.
    /// Unless otherwise noted, objects defined by this specification MUST NOT contain any additional members. Client and server implementations MUST ignore members not recognized by this specification.
    /// 
    /// RULE[0] - MUST send all JSON API data in response documents with the header Content-Type: application/vnd.api+json without any media type parameters.
    /// RULE[1] - MUST respond with a 415 Unsupported Media Type status code if a request specifies the header Content-Type: application/vnd.api+json with any media type parameters.
    /// RULE[2] - MUST respond with a 406 Not Acceptable status code if a request’s Accept header contains the JSON API media type and all instances of that media type are modified with media type parameters.
    /// RULE[3] - A JSON object MUST be at the root of every JSON API request and response containing data. This object defines a document’s “top level”.
    /// RULE[4] - ATLEAST ONE of DataObjectProperty,  ErrorsObjectProperty or MetaObjectProperty MUST be included in response.
    /// RULE[5] - A logical collection of resources MUST be represented as an array, even if it only contains one item or is empty.
    /// RULE[6] - A request MUST completely succeed or fail (in a single “transaction”). No partial updates are allowed.
    /// RULE[7] - A resource can be updated by sending a PATCH request to the URL that represents the resource. The PATCH request MUST include a single resource object as primary data. The resource object MUST contain type and id members.
    ///
    /// -- HTTP RESPONSES --
    /// 
    /// RULE - [200 OK]         If a server accepts an update but also changes the resource(s) in ways other than those specified by the request (for example, updating the updated-at attribute or a computed sha), it MUST return a 200 OK response.
    ///                         The response document MUST include a representation of the updated resource(s) as if a GET request was made to the request URL.
    /// RULE - [201 Created]    If a POST request did not include a Client-Generated ID and the requested resource has been created successfully, the server MUST return a 201 Created status code.
    ///                         The response SHOULD include a Location header identifying the location of the newly created resource.
    ///                         The response MUST also include a document that contains the primary resource created.
    /// RULE - [202 Accepted]   If a request to create a resource has been accepted for processing, but the processing has not been completed by the time the server responds, the server MUST return a 202 Accepted status code.
    /// RULE - [204 No Content] If a POST request did include a Client-Generated ID and the requested resource has been created successfully, the server MUST return either a 201 Created status code and response document (as described above) or a 204 No Content status code with no response document.
    /// RULE - [403 Forbidden]  A server MAY return 403 Forbidden in response to an unsupported request to create a resource.
    /// RULE - [404 Not Found]  A server MUST return 404 Not Found when processing a request that references a related resource that does not exist.
    /// RULE - [409 Conflict]   A server MUST return 409 Conflict when processing a POST request to create a resource with a client-generated ID that already exists.
    ///                         A server MUST return 409 Conflict when processing a POST request in which the resource object’s type is not among the type(s) that constitute the collection represented by the endpoint.
    ///                         A server SHOULD include error details and provide enough information to recognize the source of the conflict.
    /// RULE -                  A server MAY respond with other HTTP status codes.A server MAY include error details with error responses.
    ///                         A server MUST prepare responses, and a client MUST interpret responses, in accordance with HTTP semantics.
    ///
    /// -- QUERY PARAMETERS --
    /// Implementation specific query parameters MUST adhere to the same constraints as member names with the additional requirement that they MUST contain at least one non a-z character (U+0061 to U+007A). It is RECOMMENDED that a U+002D HYPHEN-MINUS, “-“, U+005F LOW LINE, “_”, or capital letter is used (e.g. camelCasing).
    /// If a server encounters a query parameter that does not follow the naming conventions above, and the server does not know how to process it as a query parameter from this specification, it MUST return 400 Bad Request.
    ///
    /// -- ERRORS --
    /// A server MAY choose to stop processing as soon as a problem is encountered, or it MAY continue processing and encounter multiple problems. For instance, a server might process multiple attributes and then return multiple validation problems in a single response.
    /// When a server encounters multiple problems for a single request, the most generally applicable HTTP error code SHOULD be used in the response.For instance, 400 Bad Request might be appropriate for multiple 4xx errors or 500 Internal Server Error might be appropriate for multiple 5xx errors.
    ///
    /// [RFC6901] - https://tools.ietf.org/html/rfc6901
    /// </summary>
    public static class JsonApiSpecification
    {
        public const string FormatName = "vnd.api+json";
        public const string MediaTypeHeaderValue = "application/vnd.api+json";

        /// <summary>
        /// “Resource objects” appear in a JSON API document to represent resources.
        /// RULE - Within a given API, each resource object’s type and id pair MUST identify a single, unique resource. 
        /// </summary>
        public static class ResourceObject
        {   
            //{
            //    "data": {
            //        "type": "articles",
            //        "id": "1",
            //        "attributes": {
            //            // ... this article's attributes
            //        },
            //        "relationships": {
            //            // ... this article's relationships
            //        }
            //    }
            //}

        /// <summary>
        /// REQUIRED
        /// EXCEPTION - The id member is not required when the resource object originates at the client and represents a new resource to be created on the server.
        /// RULE - Must be string
        /// </summary>
        public const string Id = "id";

            /// <summary>
            /// REQUIRED - The type of the resource.
            /// RULE - Must be string
            /// 
            /// value of type can be either plural or singular. However, the same value should be used consistently throughout an implementation
            /// </summary>
            public const string Type = "type";

            /// <summary>
            /// OPTIONAL - an attributes object representing some of the resource’s data.
            /// Ex: "attributes": { "title": "Some dudes" }
            /// </summary>
            public static class AttributesField
            {
                public const string AttributesFieldName = "attributes";
            }

            /// <summary>
            /// OPTIONAL - a relationships object describing relationships between the resource and other JSON API resources.
            /// 
            /// The value of the relationships key MUST be an object (a “relationships object”).
            /// Members of the relationships object (“relationships”) represent references from the resource object in which it’s defined to other resource objects.
            /// A relationship object that represents a to-many relationship MAY also contain pagination links under the links member.
            /// Any pagination links in a relationship object MUST paginate the relationship data, not the related resources.
            ///
            /// RULE - MUST contain at least one of: 'links', 'data' or 'meta'.
            /// </summary>
            public static class RelationshipsField
            {
                public const string RelationshipsFielddName = "relationships";

                /// <summary>
                /// OPTIONAL - a links object containing at least one of the following: 'self' or 'related'.
                /// RULE - Pagination links are only valid for collections. Any pagination links in a relationship object MUST paginate the relationship data, not the related resources.
                /// RULE - Pagination Keys (first, next, prev, last) MUST either be omitted or have a null value to indicate that a particular link is unavailable.
                /// RULE - Concepts of order, as expressed in the naming of pagination links, MUST remain consistent with JSON API’s sorting rules [http://jsonapi.org/format/#fetching-sorting].
                /// RULE - The 'page' query parameter is reserved for pagination. Servers and clients SHOULD use this key for pagination operations.
                /// RULE - The 'filter' query parameter is reserved for filtering data. Servers and clients SHOULD use this key for filtering operations.
                /// </summary>
                public static class Links
                {
                    public const string LinksName = "links";

                    /// <summary>
                    /// OPTIONAL - a related resource link
                    /// </summary>
                    public const string Related = "related";

                    /// <summary>
                    /// OPTIONAL - a link for the relationship itself (a “relationship link”).
                    ///
                    /// This link allows the client to directly manipulate the relationship. For example, removing an author through an article’s relationship URL
                    /// would disconnect the person from the article without deleting the people resource itself.
                    /// When fetched successfully, this link returns the linkage for the related resources as its primary data. (See Fetching Relationships.)
                    /// </summary>
                    public const string Self = "self";
                    
                    /// <summary>
                    /// OPTIONAL - the first page of data
                    /// </summary>
                    public const string First = "first";

                    /// <summary>
                    /// OPTIONAL - the last page of data
                    /// </summary>
                    public const string Last = "last";

                    /// <summary>
                    /// OPTIONAL - the previous page of data
                    /// </summary>
                    public const string Previous = "prev";

                    /// <summary>
                    /// OPTIONAL - the next page of data
                    /// </summary>
                    public const string Next = "next";
                }
               

                
            }

            public static class SharedFieldMembers
            {
                /// <summary>
                /// OPTIONAL - a links object containing links related to the resource.
                /// Ex: "relationships": { "followers": { "links": { "self": "/articles/1/followers" } }
                /// </summary>
                public const string Links = "links";

                /// <summary>
                /// OPTIONAL - a meta object containing non-standard meta-information about a resource that can not be represented as an attribute or relationship.
                /// </summary>
                public const string Meta = "meta";
            }
        }

        /// <summary>
        /// The root / top level of the API response.
        /// </summary>
        public static class TopLevel
        {
            /// <summary>
            /// OPTIONAL (INVALID if ErrorsObjectProperty is present) -  the document’s “primary data”
            /// The document’s “primary data” is a representation of the resource or collection of resources targeted by a request.
            /// RULE - See header RULE[4] for document requirement.
            ///
            /// Primary data MUST be either:
            ///     * a single resource object, a single resource identifier object, or null, for requests that target single resources
            ///     * an array of resource objects, an array of resource identifier objects, or an empty array([]), for requests that target resource collections
            /// </summary>
            public static class Data
            {
                public const string DataName = "data";
            }

            /// <summary>
            /// OPTIONAL (INVALID if DataObjectProperty is present) - an array of error objects
            /// RULE[1] - See header RULE[4] for document requirement.
            ///
            /// Error objects provide additional information about problems encountered while performing an operation. Error objects MUST be returned as an array keyed by errors in the top level of a JSON API document.
            /// </summary>
            public static class Errors
            {
                public const string ErrorsName = "errors";

                /// <summary>
                /// OPTIONAL - a unique identifier for this particular occurrence of the problem.
                /// </summary>
                public const string Id = "id";

                /// <summary>
                /// OPTIONAL - the HTTP status code applicable to this problem, expressed as a string value.
                /// </summary>
                public const string Status = "status";
                /// <summary>
                /// OPTIONAL - an application-specific error code, expressed as a string value.
                /// </summary>
                public const string Code = "code";
                /// <summary>
                /// OPTIONAL - a short, human-readable summary of the problem that SHOULD NOT change from occurrence to occurrence of the problem, except for purposes of localization.
                /// </summary>
                public const string Title = "title";

                /// <summary>
                /// OPTIONAL - a human-readable explanation specific to this occurrence of the problem. Like title, this field’s value can be localized.
                /// </summary>
                public const string Detail = "detail";

                /// <summary>
                /// OPTIONAL - a meta object containing non-standard meta-information about the error.
                /// </summary>
                public const string ErrorsMeta = "meta";

                /// <summary>
                /// OPTIONAL - a links object containing the following members:
                /// </summary>
                public static class ErrorsLinks
                {
                    public const string LinksName = "links";

                    /// <summary>
                    /// OPTIONAL -  a link that leads to further details about this particular occurrence of the problem.
                    /// </summary>
                    public const string About = "about";
                }

                /// <summary>
                /// OPTIONAL - an object containing references to the source of the error, optionally including any of the following members:
                /// </summary>
                public static class Source
                {
                    public const string SourceName = "source";

                    /// <summary>
                    /// OPTIONAL - a JSON Pointer [RFC6901] to the associated entity in the request document [e.g. "/data" for a primary data object, or "/data/attributes/title" for a specific attribute].
                    /// </summary>
                    public const string Pointer = "pointer";

                    /// <summary>
                    /// OPTIONAL - a string indicating which URI query parameter caused the error. meta: a meta object containing non-standard meta-information about the error.
                    /// </summary>
                    public const string SourceParameter = "parameter";
                }

            }

            /// <summary>
            /// OPTIONAL - a meta object that contains non-standard meta-information.
            /// RULE - See header RULE[4] for document requirement.
            /// </summary>
            public static class Meta
            {
                public const string MetaName = "meta";
            }

            /// <summary>
            /// OPTIONAL - an object describing the server’s implementation
            /// </summary>
            public static class JsonApi
            {
                public const string JsonApiName = "jsonapi";
            }

            /// <summary>
            /// OPTIONAL - a links object related to the primary data.
            /// </summary>
            public static class Links
            {
                public const string LinksName = "links";

                /// <summary>
                /// OPTIONAL - the link that generated the current response document.
                /// </summary>
                public const string SelfMember = "self";
                /// <summary>
                /// OPTIONAL - a related resource link when the primary data represents a resource relationship. !!pagination links for the primary data.
                /// </summary>
                public const string RelatedMember = "related";
            }

            /// <summary>
            /// OPTIONAL - an array of resource objects that are related to the primary data and/or each other (“included resources”).
            /// RULE - If a document does not contain a top-level data (DataObjectProperty) key, the included member MUST NOT be present either.
            /// </summary>
            public static class Included
            {
                public const string IncludedName = "included";
            }
        }
    }
}
