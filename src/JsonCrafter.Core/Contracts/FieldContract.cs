using System;
using System.Reflection;

namespace JsonCrafter.Core.Contracts
{
    public sealed class FieldContract : IFieldContract
    {
        public FieldContract(string nameInClass, FieldInfo field)
        {
            Name = nameInClass ?? throw new ArgumentNullException(nameof(nameInClass));
            ContractedFieldInfo = field ?? throw new ArgumentNullException(nameof(field));
        }

        public string Name { get; }
        public FieldInfo ContractedFieldInfo { get; }
    }
}
