using System.Collections.Generic;

namespace JsonCrafterOld.Configuration.Interfaces
{
    public interface IResourceMemberBuilder
    {
        ICollection<IResourceMemberEntry> Items { get; }
    }
}
