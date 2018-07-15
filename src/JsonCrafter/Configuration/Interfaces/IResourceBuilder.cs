using System.Collections.Generic;

namespace JsonCrafter.Configuration.Interfaces
{
    public interface IResourceBuilder
    {
        ICollection<IResourceEntry> Items { get; }
    }
}
