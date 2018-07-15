namespace JsonCrafter.Serialization.Contracts
{
    public interface IMember
    {
        bool IsResource { get; }
        bool IsValue { get; }
        bool IsCollection { get; }
        object GetValueFromObject(object obj);
        string Name { get; }
    }
}
