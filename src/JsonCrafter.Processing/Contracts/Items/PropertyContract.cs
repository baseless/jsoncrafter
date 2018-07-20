using System.Threading.Tasks;
using JsonCrafter.Core.Info;
using JsonCrafter.Processing.Contracts.Items;
using Newtonsoft.Json;
using JsonCrafter.Core;

namespace JsonCrafter.Processing.Contracts
{
    public class PropertyContract : IJsonContract
    {
        private readonly IValueInfo _info;

        public PropertyContract(IValueInfo info)
        {
            _info = Ensure.IsSet(info);
        }
        public async Task WriteAsync(object obj, JsonTextWriter writer)
        {
            await writer.WriteValueAsync(_info.GetValue(obj));
        }
    }
}
