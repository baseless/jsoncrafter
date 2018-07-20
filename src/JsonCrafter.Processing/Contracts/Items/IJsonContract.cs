using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JsonCrafter.Processing.Contracts.Items
{
    public interface IJsonContract
    {
        Task WriteAsync(object obj, JsonTextWriter writer);
    }
}
