using System;
using System.Collections.Generic;

namespace JsonCrafter.Core.Configuration.Interfaces
{
    public interface IConfigurationBuilder
    {
        void EnableMediaType(MediaType type);
        ITypeBuilder<T> For<T>() where T : class;
    }
}
