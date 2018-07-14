using System;
using System.Collections;
using System.Collections.Generic;
using JsonCrafter.Conversion.Shared;
using JsonCrafter.Core;
using JsonCrafter.Core.Contracts;
using JsonCrafter.Core.Contracts.Resolvers;
using JsonCrafter.Core.Helpers;
using Newtonsoft.Json.Linq;

namespace JsonCrafter.Conversion
{
    public abstract class JsonConverterBase : IJsonConverter
    {
        protected readonly ITokenConverter TokenConverter;
        protected readonly IContractResolver Resolver;
        protected readonly ITemplateBuilder TemplateBuilder;

        protected JsonConverterBase(ITokenConverter tokenConverter, IContractResolver resolver, ITemplateBuilder templateBuilder)
        {
            TokenConverter = tokenConverter ?? throw new ArgumentNullException(nameof(tokenConverter));
            Resolver = resolver ?? throw new ArgumentNullException(nameof(resolver));
            TemplateBuilder = templateBuilder ?? throw new ArgumentNullException(nameof(templateBuilder));
        }

        public abstract string FormatName { get; }
        public abstract string MediaTypeHeaderValue { get; }

        public JToken Convert(object obj)
        {
            var type = obj.GetType();

            if (TypeHelper.IsValue(type))
            {
                throw new JsonCrafterException("Strings and primitive types are not valid root elements.");
            }

            if (obj is IEnumerable enumerable)
            {
                throw new JsonCrafterException("Enumerable root objects are currently not supported"); // todo: REMOVE after support build for collections
                //return ConvertRootCollection(enumerable);
            }
            else
            {
                var contract = Resolver.Resolve(type);
                var rootObject = TemplateBuilder.BuildRoot(obj, contract);
                return ConvertBase(rootObject, obj, contract, true);
            }
        }

        private JToken ConvertRootCollection(IEnumerable enumerable) // todo: build and support collections as root elements
        {
            var tokens = new HashSet<JToken>();

            //foreach (var obj in enumerable)
            //{
            //    var type = obj.GetType();
            //    var contract = Resolver.Resolve(type);
            //    var rootObject = TemplateBuilder.BuildRoot(obj, contract);
            //    tokens.Add(ConvertBase(rootObject, obj, Resolver.Resolve(type)));
            //}

            return PostProcessRootCollection(tokens);
        }

        protected abstract JToken ConvertBase(JObject parent, object obj, ITypeContract resolver, bool isRoot = false);

        protected abstract JToken PostProcessRootCollection(IEnumerable<JToken> tokens);

        protected abstract JToken PostProcessResult(JToken token);
    }
}
