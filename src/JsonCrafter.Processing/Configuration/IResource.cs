using System.Collections.Generic;
using JsonCrafter.Processing.Configuration.Settings;

namespace JsonCrafter.Processing.Configuration
{
    public interface IResource
    {
        ICollection<IResourceSetting> Settings { get; }
    }
}
