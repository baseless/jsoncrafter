using System;
using System.Linq.Expressions;

namespace JsonCrafter.Processing.Configuration.Settings
{
    public interface ILinkSetting<TResource>
    {
        ILinkSetting<TResource> WithParam(string key, Expression<Func<TResource, Type>> parameterExpression);
    }
}
