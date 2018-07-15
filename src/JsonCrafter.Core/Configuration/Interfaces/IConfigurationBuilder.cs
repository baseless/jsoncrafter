using System;
using System.Collections.Generic;

namespace JsonCrafter.Core.Configuration.Interfaces
{
    public interface IConfigurationBuilder
    {
        void EnableMediaType(MediaType type);
        ITypeBuilder<TResource> For<TResource>(string url, params Func<TResource, string>[] values) where TResource : class;
    }
}
