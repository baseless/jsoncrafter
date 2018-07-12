using System;
using System.Linq.Expressions;

namespace JsonCrafter.Templates
{
    public interface IRuleSetTemplate
    {
    }

    public interface IRuleSetTemplate<T> : IRuleSetTemplate where T : class, new()
    {
        IRuleSetTemplate<T> LinkToSelf(string url, params Expression<Func<T, string>>[] properties);
    }
}
