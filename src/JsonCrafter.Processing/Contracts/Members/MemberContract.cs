using System.Collections.Generic;
using System.Linq;
using JsonCrafter.Core;
using JsonCrafter.Core.Exceptions;
using Newtonsoft.Json.Linq;

namespace JsonCrafter.Processing.Contracts.Members
{
    public sealed class MemberContract : IMemberContract
    {
        private readonly string _name;
        private readonly string _value;
        private readonly KeyValuePair<string, IValueInfo>[] _parameters;

        public MemberContract(string name, string value, KeyValuePair<string, IValueInfo>[] parameters)
        {
            
            _parameters = Ensure.IsSet(parameters);

            if (string.IsNullOrEmpty(name))
            {
                throw new JsonCrafterException($"name must not be empty for propery with value '{value}'.");
            }

            _name = name;

            if (string.IsNullOrEmpty(value))
            {
                throw new JsonCrafterException($"name must not be empty for propery with name '{name}'.");
            }
            
            _value = value;
        }
        public JToken GetToken(object obj) // todo: EVALUATE AND SECURE: it can happen a property targets subresource which is in class BUT NOT loaded (so objects are null). Must handle this. Either prevent getting properties from subclasses OR skip.
        {
            return new JProperty(_name, FormatValue(_value, _parameters, obj));
        }

        private static string FormatValue(string value, KeyValuePair<string, IValueInfo>[] parameters, object obj)
        {
            return parameters.Aggregate(value, (current, p) => current.Replace('{' + p.Key + '}', p.Value.GetValue(obj).ToString()));
        }
    }
}
