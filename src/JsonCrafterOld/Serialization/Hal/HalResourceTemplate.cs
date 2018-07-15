using System;
using JsonCrafterOld.Configuration.Interfaces;
using JsonCrafterOld.Serialization.Interfaces;
using Newtonsoft.Json.Linq;

namespace JsonCrafterOld.Serialization.Hal
{
    public class HalResourceTemplate : IResourceTemplate
    {
        private readonly string _rootTemplate;
        private readonly string _objectTemplate;
        private readonly string _relatedResourceTemplate;

        public HalResourceTemplate(JObject rootTemplate, JObject objectTemplate, JObject relatedResourceTemplate) // todo: do performance test. Is Parse faster than to copy JObjects?
        {
            _rootTemplate = rootTemplate != default(JObject) ? rootTemplate.ToString() : throw new ArgumentNullException(nameof(rootTemplate));
            _objectTemplate = objectTemplate != default(JObject) ? objectTemplate.ToString() : throw new ArgumentNullException(nameof(objectTemplate));
            _relatedResourceTemplate = relatedResourceTemplate != default(JObject) ? relatedResourceTemplate.ToString() : throw new ArgumentNullException(nameof(rootTemplate));
        }

        public JObject NewResource(IResourceMember member, IResourceContract contract)
        {
            return new JObject(_relatedResourceTemplate); // todo: here needs work
        }

        public JObject NewRoot(object obj) => JObject.Parse(_rootTemplate);

        public JObject NewObject(object obj) => JObject.Parse(_objectTemplate);
    }
}
