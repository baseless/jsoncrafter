using System;

namespace JsonCrafter.Core.Configuration
{
    public interface ITypeBuilder<out T> where T: class
    {
        ITypeBuilder<T> HasTemplate(string url, string templateIdentifier);
        ITypeBuilder<T> HasRelatedResource(Func<T, object> resource);

        ITypeBuilder<T> HasLinkToSelf(string url, params string[] values);
        ITypeBuilder<T> HasLinkToSelf(string url, params Func<T, object>[] values);
        ITypeBuilder<T> HasLink(string name, string templateId, string url, params Func<T, object>[] values);
        ITypeBuilder<T> HasLink(string name, string templateId, string url, params string[] values);
    }
}
