﻿namespace JsonCrafterOld.Serialization.Interfaces
{
    public interface IResourceMember
    {
        bool IsRelatedResource { get; }
        bool IsValue { get; }
        bool IsCollection { get; }
        object GetValueFromObject(object obj);
        string Name { get; }
    }
}