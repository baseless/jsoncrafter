using System.Reflection;

namespace JsonCrafter.Conversion
{
    public class ResourceProperty : ResourceMemberBase<PropertyInfo>
    {
        public ResourceProperty(string propName, PropertyInfo propInfo, bool isResource = false) : base(propName, propInfo, isResource, propInfo.PropertyType)
        {
        }

        public override object GetValueFromObject(object obj)
        {
            return Info.GetValue(obj);
        }
    }
}
