using System;
using System.Collections.Generic;
using System.Linq;
using JsonCrafter.Configuration;
using JsonCrafter.Configuration.Interfaces;
using JsonCrafter.ContentTypes.Hal.Interfaces;
using JsonCrafter.Conversion;
using JsonCrafter.Conversion.Interfaces;
using JsonCrafter.Settings;
using Newtonsoft.Json.Linq;

namespace JsonCrafter.ContentTypes.Hal
{
    public class HalResourceContractBuilder : ResourceContractBuilderBase, IHalResourceContractBuilder
    {
        public HalResourceContractBuilder(IJsonCrafterBuilderAction builderAction) : base(builderAction)
        {
            
        }

        public IResourceContractResolver Build()
        {
            BuilderAction.Invoke(this);

            var defaultTemplate = new HalResourceTemplate(JObject.Parse("{'defaultTemplate': 'true'}"), JObject.Parse("{}"), JObject.Parse("{}")); // todo: RPEFORMANCE: test if jobject.parse("{}") is slower than new Jobject()
            var constructedTemplates = new Dictionary<Type, IResourceTemplate>();

            foreach (var builder in Builders)
            {
                var root = BuildRoot(builder.Key, builder.Value); // Build template for the resource root resource
                var obj = BuildObject(builder.Key, builder.Value); // Build template for non-root resource
                var related = BuildRelatedResourceBase(builder.Key, builder.Value); // Build template for the (embedded) related resources base object.

                constructedTemplates.Add(builder.Key, new HalResourceTemplate(root, obj, related));
            }
            

            return new ResourceContractResolver(
                constructedTemplates, 
                defaultTemplate, 
                null
                //Builders.Where(b => b.Value.Items.Any(a => a.AppendixType.Equals(ResourceAppendixType.OneToManyRelation) || a.AppendixType.Equals(ResourceAppendixType.OneToOneRelation)))
                //    .Select(k => k.Key)
                //    .ToList()
            );
        }

        private static JObject BuildRoot(Type type, IResourceBuilder builder)
        {
            var obj = JObject.Parse("{ 'halJsonVersion': '0.0.1-alpha1' }");

            return obj;
        }

        private static JObject BuildObject(Type type, IResourceBuilder builder)
        {
            var obj = new JObject();

            return obj;
        }

        private static JObject BuildRelatedResourceBase(Type type, IResourceBuilder builder)
        {
            var obj = new JObject();

            return obj;
        }
    }
}
