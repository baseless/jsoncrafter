namespace JsonCrafter.Serialization.Contracts.Members
{
    public interface IContractMember
    {
        bool IsRelatedResource { get; }
        bool IsValue { get; }
        bool IsCollection { get; }
        object GetValueFromObject(object obj);
        string Name { get; }
    }
}
