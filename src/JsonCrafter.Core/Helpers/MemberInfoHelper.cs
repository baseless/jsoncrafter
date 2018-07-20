using System.Reflection;
using JsonCrafter.Core.Info;

namespace JsonCrafter.Core.Helpers
{
    public static class MemberInfoHelper
    {
        public static IValueInfo GetValueInfo(this MemberInfo info)
        {
            switch (info)
            {
                case PropertyInfo propInfo:
                    return new PropertyValueInfo(propInfo);
                case FieldInfo fieldInfo:
                    return new FieldValueInfo(fieldInfo);
                default:
                    return null;
            }
        }
    }
}
