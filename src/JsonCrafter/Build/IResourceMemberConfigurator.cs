using System.Collections.Generic;

namespace JsonCrafter.Build
{
    public interface IResourceMemberConfigurator
    {
        ICollection<IResourceMemberEntry> Entries { get; }
    }
}
