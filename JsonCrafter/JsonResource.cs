using System;
using System.Linq.Expressions;

namespace JsonCrafter
{
    public enum JsonResourceType
    {
        LinkToSelf,
        Link
    }

    public sealed class JsonResource
    {
        public JsonResourceType Type { get; set; }
        public string Key { get; set; }
        public string Url { get; set; }
    }

    public class JsonResource<T> : JsonResource where T: class, new()
    {
        public Expression<Func<T, string>>[] Properties { get; set; }
    }
}
