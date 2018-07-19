using System.Collections.Generic;
using System.Linq;
using JsonCrafter.Core;
using Newtonsoft.Json.Linq;

namespace JsonCrafter.Processing.Contracts.Members
{
    public class ObjectContract : IMemberContract
    {
        private readonly KeyValuePair<string, IMemberContract>[] _children;

        public ObjectContract(IEnumerable<KeyValuePair<string, IMemberContract>> children)
        {
            _children = Ensure.IsSet(children).ToArray();
        }
        public JToken GetToken(object obj)
        {
            return CreateObject(obj, _children);
        }

        private static JToken CreateObject(object obj, KeyValuePair<string, IMemberContract>[] children)
        {
            var jsonObj = new JObject();

            foreach (var child in children)
            {
                jsonObj.Add(new JProperty(child.Key, child.Value.GetToken(obj)));
            }

            return jsonObj;
        }
    }
}
