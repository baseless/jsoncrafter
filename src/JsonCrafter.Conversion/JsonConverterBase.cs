using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using JsonCrafter.Conversion.Shared;
using JsonCrafter.Core;
using JsonCrafter.Core.Contracts;
using JsonCrafter.Core.Contracts.Resolvers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonCrafter.Conversion
{
    public abstract class JsonConverterBase : IJsonConverter
    {
        protected readonly ITokenConverter TokenConverter;
        protected readonly IContractResolver Resolver;

        protected JsonConverterBase(ITokenConverter tokenConverter, IContractResolver resolver)
        {
            TokenConverter = tokenConverter ?? throw new ArgumentNullException(nameof(tokenConverter));
            Resolver = resolver ?? throw new ArgumentNullException(nameof(resolver));
        }

        public abstract string FormatName { get; }
        public abstract string MediaTypeHeaderValue { get; }

        public JToken Convert(object obj)
        {
            var watch = new Stopwatch();
            watch.Start();
            var res = JsonConvert.SerializeObject(obj);
            watch.Stop();
            var newtonSoftElapsed = watch.ElapsedMilliseconds;
            watch.Reset();
            watch.Start();
            JToken result;
            
            if (obj is IEnumerable enumerable)
            {
                result = ConvertEnumerable(enumerable);
            }
            else
            {
                result = ConvertObject(obj, Resolver.Resolve(obj.GetType()));
            }
            watch.Stop();
            var jsonCrafterElapsed = watch.ElapsedMilliseconds;
            Debug.WriteLine($"!!!!!!! {nameof(newtonSoftElapsed)} took {newtonSoftElapsed} ms");
            Debug.WriteLine($"!!!!!!! {nameof(jsonCrafterElapsed)} took {jsonCrafterElapsed} ms");
            return result;
        }

        private JToken ConvertEnumerable(IEnumerable enumerable)
        {
            var tokens = new HashSet<JToken>();

            foreach (var obj in enumerable)
            {
                tokens.Add(ConvertObject(obj, Resolver.Resolve(obj.GetType())));
            }

            return PostProcessEnumerable(tokens);
        }
        
        protected abstract JToken ConvertObject(object obj, ITypeContract resolver);

        protected abstract JToken PostProcessEnumerable(IEnumerable<JToken> tokens);

        protected abstract JToken PostProcessResult(JToken token);
    }
}
