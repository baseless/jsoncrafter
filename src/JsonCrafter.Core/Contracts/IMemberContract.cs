namespace JsonCrafter.Core.Contracts
{
    public interface IMemberContract
    {
        bool IsResource { get; }
        object GetValueFromObject(object obj);
        string Name { get; }
    }
}
