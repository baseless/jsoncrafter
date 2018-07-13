using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace JsonCrafter.Conversion.Shared
{
    public interface ITokenConverter
    {
        IList<JProperty> GetMembers(object obj);
    }
}
