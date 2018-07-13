using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace JsonCrafter.Conversion.Shared
{
    public class TokenConverter : ITokenConverter
    {
        public IList<JProperty> GetMembers(object obj)
        {
            return null;
        }
    }
}
