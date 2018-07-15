using System.Reflection;

namespace JsonCrafter.Contracts
{
    public sealed class Field : MemberContractBase<FieldInfo>
    {
        public Field(string fieldName, FieldInfo fieldInfo, bool isResource = false) : base(fieldName, fieldInfo, isResource, fieldInfo.FieldType)
        {
            var type = fieldInfo.ReflectedType;
        }
        
        public override object GetValueFromObject(object obj)
        {
            return Info.GetValue(obj);
        }
        
    }
}
