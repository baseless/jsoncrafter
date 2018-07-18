using System;

namespace JsonCrafter.Core.Summary
{
    public interface IMemberSummary
    {
        string Name { get; }
        Type MemberType { get; }
    }
}
