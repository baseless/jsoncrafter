using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using JsonCrafter.Core;
using Newtonsoft.Json;

namespace JsonCrafter.Processing.Contracts.Items
{
    public sealed class TypeContract : ITypeContract
    {
        private readonly IImmutableList<KeyValuePair<string, IJsonContract>> _members;

        public TypeContract(IList<KeyValuePair<string, IJsonContract>> members)
        {
            _members = Ensure.IsSet(members).ToImmutableList();
        }

        public async Task WriteAsync(object obj, JsonTextWriter writer)
        {
            await writer.WriteStartObjectAsync();
            foreach (var member in _members)
            {
                await writer.WritePropertyNameAsync(member.Key);
                await member.Value.WriteAsync(obj, writer);
            }
            await writer.WriteEndObjectAsync();
        }
    }
}
