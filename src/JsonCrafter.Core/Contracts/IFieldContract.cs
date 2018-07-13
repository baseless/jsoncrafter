using System;
using System.Reflection;

namespace JsonCrafter.Core.Contracts
{
    public interface IFieldContract
    {
        string Name { get; }
        FieldInfo ContractedFieldInfo { get; }
    }
}
