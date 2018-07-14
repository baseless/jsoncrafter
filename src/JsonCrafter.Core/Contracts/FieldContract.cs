using System;
using System.Reflection;

namespace JsonCrafter.Core.Contracts
{
    public sealed class FieldContract : IMemberContract
    {
        public FieldContract(string fieldName, FieldInfo fieldInfo, bool isResource = false)
        {
            IsResource = isResource;
            Name = fieldName ?? throw new ArgumentNullException(nameof(fieldName));
            Info = fieldInfo ?? throw new ArgumentNullException(nameof(fieldInfo));
        }
        
        public bool IsResource { get; }

        public object GetValueFromObject(object obj)
        {
            return Info.GetValue(obj);
        }

        public string Name { get; }
        internal readonly FieldInfo Info;
    }
}
