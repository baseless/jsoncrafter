using System.Reflection;

namespace JsonCrafter.Contracts
{
    public class Property : MemberContractBase<PropertyInfo>
    {
        public Property(string propName, PropertyInfo propInfo, bool isResource = false) : base(propName, propInfo, isResource, propInfo.PropertyType)
        {
        }

        public override object GetValueFromObject(object obj)
        {
            return Info.GetValue(obj);
        }
    }
}
