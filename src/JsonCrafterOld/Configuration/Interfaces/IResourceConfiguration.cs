﻿using System;
using System.Linq.Expressions;

namespace JsonCrafterOld.Configuration.Interfaces
{
    public interface IResourceConfiguration<TResource> where TResource : class
    {
        //ITypeBuilder<T> HasTemplate(string url, string templateIdentifier);
        IResourceConfiguration<TResource> ContainsResource(Expression<Func<TResource, object>> resource);

        //ITypeBuilder<T> HasLinkToSelf(string url, params string[] values);
        //ITypeBuilder<T> HasLinkToSelf(string url, params Func<T, object>[] values);
        //ITypeBuilder<T> HasLink(string name, string templateId, string url, params Func<T, object>[] values);
        //ITypeBuilder<T> HasLink(string name, string templateId, string url, params string[] values);
    }
}