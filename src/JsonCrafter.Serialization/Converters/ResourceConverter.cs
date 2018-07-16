using System;
using System.Collections;
using System.Collections.Generic;
using JsonCrafter.Serialization.Contracts;
using JsonCrafter.Shared;
using JsonCrafter.Shared.Exceptions;
using JsonCrafter.Shared.Helpers;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace JsonCrafter.Serialization.Converters
{
    /// <summary>
    /// Base class for C# Object to JToken conversion.
    /// </summary>
    public abstract class ResourceConverter<TLogger> where TLogger: class, ILogger
    {
        protected readonly IResourceContractResolver Resolver;
        protected readonly TLogger Logger;

        protected ResourceConverter(IResourceContractResolver resolver, TLogger logger)
        {
            Resolver = Ensure.IsSet(resolver);
            Logger = Ensure.IsSet(logger);
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
                //var jsonObject = contract.Template.NewRoot(obj);
                return PostProcessResult(ConvertBase(/*jsonObject*/new JObject(), obj, contract, true));
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
        protected abstract JToken ConvertBase(JObject jsonObject, object obj, IResourceContract contract, bool isRoot = false);

        protected abstract JToken PostProcessRootCollection(IEnumerable<JToken> tokens);

        protected abstract JToken PostProcessResult(JToken token);
    }
}
