using System;
using System.Collections.Generic;
using JsonCrafterOld.Configuration.Hal.Interfaces;
using JsonCrafterOld.Configuration.Interfaces;
using JsonCrafterOld.Core.Interfaces;
using JsonCrafterOld.Serialization;
using JsonCrafterOld.Serialization.Hal;
using JsonCrafterOld.Serialization.Interfaces;
using Newtonsoft.Json.Linq;

namespace JsonCrafterOld.Configuration.Hal
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

        private static JObject BuildRoot(Type type, IResourceMemberBuilder builder)
        {
            var obj = JObject.Parse("{ 'halJsonVersion': '0.0.1-alpha1' }");

            return obj;
        }

        private static JObject BuildObject(Type type, IResourceMemberBuilder builder)
        {
            var obj = new JObject();

            return obj;
        }

        private static JObject BuildRelatedResourceBase(Type type, IResourceMemberBuilder builder)
        {
            var obj = new JObject();

            return obj;
        }
    }
}
