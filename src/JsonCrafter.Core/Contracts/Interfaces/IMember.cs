namespace JsonCrafter.Core.Contracts.Interfaces
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
