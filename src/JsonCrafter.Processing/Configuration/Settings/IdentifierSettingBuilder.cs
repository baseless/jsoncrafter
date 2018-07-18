using JsonCrafter.Core;
using JsonCrafter.Core.Enums;
using JsonCrafter.Core.Summary;

namespace JsonCrafter.Processing.Configuration.Settings
{
    /// <summary>
    /// Setting that specifies a resources primary identifier.
    /// Can be stacked if composite keys are used.
    /// NOTE: Not used by all formats (JsonAPI utilizes Id but HAL does not).
    /// </summary>
    /// <typeparam name="TResource">The type of resource this setting applies to</typeparam>
    public sealed class IdentifierSettingBuilder<TResource> : ResourceSettingBase<TResource>, IResourceSetting where TResource: class
    {
        private readonly  IMemberSummary _memberSummary;

        public IdentifierSettingBuilder(IConfigurationBuilder parentBuilder, IResourceBuilder<TResource> parentResource, IMemberSummary memberSummary) : base(parentBuilder, parentResource)
        {
            _memberSummary = Ensure.IsSet(memberSummary);
        }

        public ResourceSettingsType SettingsType => ResourceSettingsType.Identifier;
    }
}
