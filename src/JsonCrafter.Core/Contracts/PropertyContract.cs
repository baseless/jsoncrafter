using System;
using System.Reflection;

namespace JsonCrafter.Core.Contracts
{
    public class PropertyContract : IMemberContract
    {
        public PropertyContract(string propName, PropertyInfo propInfo, bool isResource = false)
        {
            IsResource = isResource;
            Name = propName ?? throw new ArgumentNullException(nameof(propName));
            Info = propInfo ?? throw new ArgumentNullException(nameof(propInfo));
        }
        
        public bool IsResource { get; }

        public object GetValueFromObject(object obj)
        {
            return Info.GetValue(obj);
        }

        public string Name { get; }
        internal PropertyInfo Info { get; }
    }
}
