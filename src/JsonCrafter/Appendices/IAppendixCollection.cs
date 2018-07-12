using System;

namespace JsonCrafter.Appendices
{
    public interface IAppendixCollection
    {
        IAppendixTypeSet ForType(Type type);
    }
}
