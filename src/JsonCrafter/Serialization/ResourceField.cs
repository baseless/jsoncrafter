using System.Reflection;

namespace JsonCrafter.Serialization
{
    public sealed class ResourceField : ResourceMemberBase<FieldInfo>
    {
        public ResourceField(string fieldName, FieldInfo fieldInfo, bool isResource = false) : base(fieldName, fieldInfo, isResource, fieldInfo.FieldType)
        {
            var type = fieldInfo.ReflectedType;
        }
        
        public override object GetValueFromObject(object obj)
        {
            return Info.GetValue(obj);
        }
        
    }
}
