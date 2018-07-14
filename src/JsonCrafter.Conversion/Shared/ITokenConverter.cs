using System.Collections.Generic;
using JsonCrafter.Core.Contracts;
using Newtonsoft.Json.Linq;

namespace JsonCrafter.Conversion.Shared
{
    public interface ITokenConverter
    {
        JProperty BuildProperty(IMemberContract member);
    }
}
