using System;
using System.Reflection;

namespace JsonCrafter.Core.Summary
{
    public class FieldSummary : IMemberSummary
    {
        public string Name => _fieldInfo.Name;
        private readonly FieldInfo _fieldInfo;
        public Type MemberType => _fieldInfo.FieldType;
        public FieldSummary(FieldInfo fieldInfo)
        {
            _fieldInfo = Ensure.IsSet(fieldInfo);
        }
    }
}
