namespace JsonCrafter.Conversion.Interfaces
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
