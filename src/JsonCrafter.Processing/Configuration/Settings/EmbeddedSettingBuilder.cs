using JsonCrafter.Core;
using JsonCrafter.Core.Enums;
using JsonCrafter.Core.Summary;

namespace JsonCrafter.Processing.Configuration.Settings
{
    /// <summary>
    /// Specifies what embedded relationship the resource has
    /// </summary>
    /// <typeparam name="TResource">The type of resource this setting applies to</typeparam>
    public sealed class EmbeddedSettingBuilder<TResource> : ResourceSettingBase<TResource>, IResourceSetting, IEmbeddedSettingBuilder where TResource: class
    {
        private readonly IMemberSummary _summary;

        public EmbeddedSettingBuilder(IConfigurationBuilder parentBuilder, IResourceBuilder<TResource> parentResource, IMemberSummary summary) : base(parentBuilder, parentResource)
        {
            _summary = Ensure.IsSet(summary);
        }

        public ResourceSettingsType SettingsType => ResourceSettingsType.Embedded;
    }
}
