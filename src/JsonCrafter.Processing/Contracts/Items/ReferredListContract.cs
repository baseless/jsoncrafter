using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JsonCrafter.Processing.Contracts.Items
{
    public class ReferredListContract : IJsonContract
    {
        public async Task WriteAsync(object obj, JsonTextWriter writer)
        {
            await writer.WriteValueAsync("HE WILL BE NESTED LIST");
        }
    }
}
