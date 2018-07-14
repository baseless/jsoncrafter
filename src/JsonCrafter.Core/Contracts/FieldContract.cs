using System.Collections;
using System.Reflection;

namespace JsonCrafter.Core.Contracts
{
    public sealed class FieldContract : MemberContractBase<FieldInfo>
    {
        public FieldContract(string fieldName, FieldInfo fieldInfo, bool isResource = false) : base(fieldName, fieldInfo, isResource, fieldInfo.FieldType)
        {
            var type = fieldInfo.ReflectedType;
        }
        
        public override object GetValueFromObject(object obj)
        {
            return Info.GetValue(obj);
        }
        
    }
}
