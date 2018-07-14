namespace JsonCrafter.Core.Contracts
{
    public interface IMemberContract
    {
        bool IsResource { get; }
        bool IsValue { get; }
        bool IsCollection { get; }
        object GetValueFromObject(object obj);
        string Name { get; }
    }
}
