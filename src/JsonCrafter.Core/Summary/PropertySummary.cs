using System;
using System.Reflection;

namespace JsonCrafter.Core.Summary
{
    public class PropertySummary : IMemberSummary
    {
        public string Name => _propInfo.Name;
        public Type MemberType => _propInfo.PropertyType;
        private readonly PropertyInfo _propInfo;

        public PropertySummary(PropertyInfo propInfo)
        {
            _propInfo = Ensure.IsSet(propInfo);
        }
    }
}
