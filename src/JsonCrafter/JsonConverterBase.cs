using System;
using System.Collections;
using System.Collections.Generic;
using JsonCrafter.Configuration.Interfaces;
using JsonCrafter.Contracts.Interfaces;
using JsonCrafter.Helpers;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace JsonCrafter
{
    /// <summary>
    /// Base class for C# Object to JToken conversion.
    /// </summary>
    internal abstract class JsonConverterBase<TConverter> : IJsonConverter where TConverter: IJsonConverter
    {
        protected readonly IContractResolver<TConverter> Resolver;
        protected readonly ILogger<TConverter> Logger;

        protected JsonConverterBase(IContractResolver<TConverter> resolver, ILogger<TConverter> logger)
        {
            Resolver = resolver ?? throw new ArgumentNullException(nameof(resolver));
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
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
                var jsonObject = contract.Template.GetRoot(obj);
                return PostProcessResult(ConvertBase(jsonObject, obj, contract, true));
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

        /// <summary>
        /// The underlying Converter method, responsible for converting a C# object into a JToken.
        /// </summary>
        /// <param name="jsonObject">The json object that the C# object will be mapped into</param>
        /// <param name="obj">The C# object instance that are being converted.</param>
        /// <param name="contract">The objects TypeContract</param>
        /// <param name="isRoot">If the objectBase is the root element of the response</param>
        /// <returns></returns>
        protected abstract JToken ConvertBase(JObject jsonObject, object obj, IContract contract, bool isRoot = false);

        protected abstract JToken PostProcessRootCollection(IEnumerable<JToken> tokens);

        protected abstract JToken PostProcessResult(JToken token);
    }
}
