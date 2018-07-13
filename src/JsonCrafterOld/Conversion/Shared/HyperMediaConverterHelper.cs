using System;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;

namespace JsonCrafterOld.Conversion.Shared
{
    public class HyperMediaConverterHelper : IHyperMediaConverterHelper
    {
        public object[] GetValuesFromPropertyNames(JObject jsonObject, string[] propNames)
        {
            var values = new object[propNames.Length];

            for (var i = 0; i < propNames.Length; ++i)
            {
                if (propNames[i].StartsWith(JsonCrafterConstants.AppendixFormatting.SpecialPropertyPrefix)) // todo: handle special props (like url params and so forth)
                {
                    continue;
                }

                var val = jsonObject.GetValue(propNames[i], StringComparison.OrdinalIgnoreCase);

                if (val != null)
                {
                    values[i] = val.Type.Equals(JTokenType.String) ? Base64UrlEncoder.Encode(val.ToString()) : val.ToString();
                }
            }

            return values;
        }

        public JProperty ConvertToProperty(string propertyName, string template, object[] propValues)
        {
            var formattedTemplate = string.Format(template, propValues);
            var appendixObject = JObject.Parse(formattedTemplate);
            return new JProperty(propertyName, appendixObject);
        }
    }
}
