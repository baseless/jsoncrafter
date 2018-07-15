using System;
using JsonCrafter.Configuration.Interfaces;

namespace JsonCrafter.Contracts.Interfaces
{
    public interface IContractResolver<TConverter> where TConverter: IJsonConverter
    {
        IContract Resolve(Type type);
    }
}
