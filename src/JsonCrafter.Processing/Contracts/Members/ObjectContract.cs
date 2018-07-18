using Newtonsoft.Json.Linq;

namespace JsonCrafter.Processing.Contracts.Members
{
    public class ObjectContract : IMemberContract
    {
        public JToken GetToken(object obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
