using Newtonsoft.Json.Linq;

namespace JsonCrafter.Processing.Contracts.Members
{
    public interface IMemberContract
    {
        JToken GetToken(object obj);
    }
}
