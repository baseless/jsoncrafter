using System.Reflection;
using Newtonsoft.Json.Linq;

namespace JsonCrafter.Processing.Contracts.Members
{
    public class FieldValueContract : IMemberContract
    {
        private readonly string _name;
        private readonly FieldInfo _info;

        public FieldValueContract(string name, FieldInfo info)
        {
            _name = name;
            _info = info;
        }

        public JToken GetToken(object obj)
        {
            return new JProperty(_name, _info.GetValue(obj));
        }
    }
}
