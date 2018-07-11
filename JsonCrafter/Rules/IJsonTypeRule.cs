using System;
using System.Linq.Expressions;

namespace JsonCrafter.Rules
{
    public interface IJsonTypeRule
    {

    }

    public interface IJsonTypeRule<T> : IJsonTypeRule where T : class, new()
    {
        IJsonTypeRule<T> LinkToSelf(string url, params Expression<Func<T, string>>[] properties);
    }
}
