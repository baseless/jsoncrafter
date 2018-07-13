using Newtonsoft.Json.Linq;

namespace JsonCrafterOld.Conversion.Shared
{
    public interface IHyperMediaConverterHelper
    {
        object[] GetValuesFromPropertyNames(JObject jsonObject, string[] propNames);
        JProperty ConvertToProperty(string propertyName, string template, object[] propValues);
    }
}
