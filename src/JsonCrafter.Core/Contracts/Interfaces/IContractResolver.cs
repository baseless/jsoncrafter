using System;
using JsonCrafter.Core.Configuration.Interfaces;

namespace JsonCrafter.Core.Contracts.Interfaces
{
    public interface IContractResolver<TConverter> where TConverter: IJsonConverter
    {
        IContract Resolve(Type type);
    }
}
