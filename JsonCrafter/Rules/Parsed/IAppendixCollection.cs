using System;

namespace JsonCrafter.Rules.Parsed
{
    public interface IAppendixCollection
    {
        IAppendix ForType(Type type);
    }
}
