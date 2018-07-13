using System.Collections;
using System.Collections.Generic;
using JsonCrafter.Core.Handlers;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json.Linq;

namespace JsonCrafter.Conversion
{
    public abstract class JsonConverterBase : IJsonConverter
    {
        protected readonly ITypeHandler TypeHandler;

        protected JsonConverterBase(ITypeHandler typeHandler)
        {
            TypeHandler = typeHandler;
        }

        public abstract string FormatName { get; }
        public abstract string MediaTypeHeaderValue { get; }

        public JToken Convert(object obj)
        {
            var type = obj.GetType();
            JToken result;
            
            if (obj is IEnumerable enumerable)
            {
                result = ConvertEnumerable(enumerable);
            }
            else
            {
                result = ConvertObject(obj);
            }

            return result;
        }

        private JToken ConvertEnumerable(IEnumerable enumerable)
        {
            var tokens = new HashSet<JToken>();

            foreach (var obj in enumerable)
            {
                tokens.Add(ConvertObject(obj));
            }

            return PostProcessEnumerable(tokens);
        }
        
        protected abstract JToken ConvertObject(object obj);

        protected abstract JToken PostProcessEnumerable(IEnumerable<JToken> tokens);

        protected abstract JToken PostProcessResult(JToken token);
    }
}
