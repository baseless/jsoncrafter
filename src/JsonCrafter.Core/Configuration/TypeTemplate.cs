using System;
using JsonCrafter.Core.Configuration.Interfaces;
using JsonCrafter.Core.Contracts.Interfaces;
using Newtonsoft.Json.Linq;

namespace JsonCrafter.Core.Configuration
{
    public class TypeTemplate : ITypeTemplate
    {
        public JObject GetResourceBase(IMember member, IContract contract)
        {
            return new JObject();
        }

        public JObject GetRoot(object obj)
        {
            return new JObject();
        }

        public JObject GetObject(object obj)
        {
            return new JObject();
        }
    }
}
