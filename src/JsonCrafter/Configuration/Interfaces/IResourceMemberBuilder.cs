using System.Collections.Generic;

namespace JsonCrafter.Configuration.Interfaces
{
    public interface IResourceMemberBuilder
    {
        ICollection<IResourceMemberEntry> Items { get; }
    }
}
