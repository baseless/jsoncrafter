using System;
using System.Collections.Generic;
using JsonCrafter.Core.Contracts;
using Newtonsoft.Json.Linq;

namespace JsonCrafter.Conversion.Shared
{
    public class TokenConverter : ITokenConverter
    {
        public IList<JProperty> GetMembers(object obj)
        {
            return null;
        }

        public JProperty BuildProperty(IMemberContract member)
        {
            throw new NotImplementedException();
        }
    }
}
