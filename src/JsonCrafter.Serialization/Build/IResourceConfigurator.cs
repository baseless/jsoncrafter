using System;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;

namespace JsonCrafter.Serialization.Build
{
    public interface IResourceConfigurator<TResource> where TResource : class
    {
        //ITypeBuilder<T> HasTemplate(string url, string templateIdentifier);
        IResourceConfigurator<TResource> ContainsResource(Expression<Func<TResource, object>> resource);

        //ITypeBuilder<T> HasLinkToSelf(string url, params string[] values);
        //ITypeBuilder<T> HasLinkToSelf(string url, params Func<T, object>[] values);
        //ITypeBuilder<T> HasLink(string name, string templateId, string url, params Func<T, object>[] values);
        //ITypeBuilder<T> HasLink(string name, string templateId, string url, params string[] values);

        IResourceConfigurator<TNew> For<TNew>(string url, params Expression<Func<TNew, Type>>[] parameterTypes) where TNew : class;
    }
}
