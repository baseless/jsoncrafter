using System.Reflection;

namespace JsonCrafter.Core.Contracts
{
    public class PropertyContract : MemberContractBase<PropertyInfo>
    {
        public PropertyContract(string propName, PropertyInfo propInfo, bool isResource = false) : base(propName, propInfo, isResource, propInfo.PropertyType)
        {
        }

        public override object GetValueFromObject(object obj)
        {
            return Info.GetValue(obj);
        }
    }
}
