using JsonCrafterOld.Appendices;
using JsonCrafterOld.Conversion.Shared;

namespace JsonCrafterOld.Conversion.Hal
{
    public sealed class HalAppendixBuilder<TConverter> : AppendixBuilder<TConverter> where TConverter : HyperMediaOutputConverter<TConverter>
    {
        public override IAppendixCollection<TConverter> Build()
        {
            return new AppendixCollection<TConverter>();
        }
    }
}
