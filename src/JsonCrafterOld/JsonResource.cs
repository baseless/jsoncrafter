using System;
using System.Linq.Expressions;

namespace JsonCrafterOld
{
    public enum JsonResourceType
    {
        LinkToSelf,
        Link
    }

    public class JsonResource
    {
        public JsonResourceType Type { get; set; }
        public string Key { get; set; }
        public string Url { get; set; }
    }

    public sealed class JsonResource<T> : JsonResource where T: class, new()
    {
        public Expression<Func<T, string>>[] Properties { get; set; }
    }
}
