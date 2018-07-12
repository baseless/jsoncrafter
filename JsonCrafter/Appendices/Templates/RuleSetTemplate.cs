using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace JsonCrafter.Templates
{
    public sealed class RuleSetTemplate<T> : IRuleSetTemplate<T> where T: class, new()
    {
        private readonly ICollection<JsonResource> _resources;

        public RuleSetTemplate()
        {
            _resources = new List<JsonResource>();
        }

        public IRuleSetTemplate<T> LinkToSelf(string url, params Expression<Func<T, string>>[] properties)
        {
            _resources.Add(new JsonResource<T> { Type = JsonResourceType.LinkToSelf, Url = url, Properties = properties });

            return this;
        }
    }
}
