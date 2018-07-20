using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using JsonCrafter.Core;
using JsonCrafter.Core.Info;
using JsonCrafter.Processing.Contracts.Items;
using Newtonsoft.Json;

namespace JsonCrafter.Processing.Contracts
{
    public class TemplatedFieldContract : IJsonContract
    {
        private readonly string _valueTemplate;
        private readonly IImmutableDictionary<string, IValueInfo> _parameters;

        public TemplatedFieldContract(string valueTemplate, IDictionary<string, IValueInfo> parameters = default(IDictionary<string, IValueInfo>))
        {
            _valueTemplate = Ensure.IsSet(valueTemplate);
            _parameters = (parameters ?? new Dictionary<string, IValueInfo>()).ToImmutableDictionary();
        }

        public async Task WriteAsync(object obj, JsonTextWriter writer)
        {
            await writer.WriteValueAsync(FormatTemplate(_valueTemplate, obj));
        }

        private static string FormatTemplate(string valueTemplate, object obj)
        {
            return valueTemplate;
        }
    }
}
