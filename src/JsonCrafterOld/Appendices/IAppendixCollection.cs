using System;

namespace JsonCrafterOld.Appendices
{
    public interface IAppendixCollection<TConverter>
    {
        IAppendixTypeSet ForType(Type type);
    }
}
