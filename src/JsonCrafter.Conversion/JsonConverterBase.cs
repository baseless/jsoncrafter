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
    /// <summary>
    /// Base class for C# Object to JToken conversion.
    /// </summary>
    public abstract class JsonConverterBase : IJsonConverter
    {
        protected readonly IContractResolver Resolver;

        protected JsonConverterBase(IContractResolver resolver)
        {
            Resolver = resolver ?? throw new ArgumentNullException(nameof(resolver));
        }

        public abstract string FormatName { get; }
        public abstract string MediaTypeHeaderValue { get; }

        /// <summary>
        /// Initializes the conversion chain using the recieved object.
        /// </summary>
        /// <param name="obj">The C# object that is about to be presented as a result to the consumer.</param>
        /// <returns></returns>
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
                //return PostProcessResult(ConvertRootCollection(enumerable));
            }
            else
            {
                var contract = Resolver.Resolve(type);
                var rootObject = contract.Template.GetRoot(obj);
                return PostProcessResult(ConvertBase(rootObject, obj, contract, true));
            }
        }

        //private JToken ConvertRootCollection(IEnumerable enumerable) // todo: build and support collections as root elements
        //{
        //    var tokens = new HashSet<JToken>();

        //    foreach (var obj in enumerable)
        //    {
        //        var type = obj.GetType();
        //        var contract = Resolver.Resolve(type);
        //        var rootObject = TemplateBuilder.BuildRoot(obj, contract);
        //        tokens.Add(ConvertBase(rootObject, obj, Resolver.Resolve(type)));
        //    }

        //    return PostProcessRootCollection(tokens);
        //}

        protected abstract JToken ConvertBase(JObject parent, object obj, ITypeContract contract, bool isRoot = false);

        protected abstract JToken PostProcessRootCollection(IEnumerable<JToken> tokens);

        protected abstract JToken PostProcessResult(JToken token);
    }
}
