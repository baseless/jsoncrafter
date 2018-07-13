using System;
using JsonCrafterOld.Appendices;
using JsonCrafterOld.Conversion.Shared;

namespace JsonCrafterOld.Conversion.JsonApi
{
    public class JsonApiAppendixBuilder<TConverter> : AppendixBuilder<TConverter> where TConverter : HyperMediaOutputConverter<TConverter>
    {
        public override IAppendixCollection<TConverter> Build()
        {
            throw new NotImplementedException();
        }
    }
}
