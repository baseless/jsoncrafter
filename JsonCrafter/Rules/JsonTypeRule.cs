using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using JsonCrafter.Rules;

namespace JsonCrafter.Rules
{
    public class JsonTypeRule<T> : IJsonTypeRule<T> where T: class, new()
    {
        private readonly ICollection<JsonResource> _resources;

        public JsonTypeRule()
        {
            _resources = new List<JsonResource>();
        }

        public IJsonTypeRule<T> LinkToSelf(string url, params Expression<Func<T, string>>[] properties)
        {
            _resources.Add(new JsonResource<T> { Type = JsonResourceType.LinkToSelf, Url = url, Properties = properties });

            return this;
        }
    }
}
