namespace JsonCrafter.Core.Configuration
{
    public interface IJsonCrafterBuilder
    {
        void EnableMediaType(MediaType type);
        ITypeContractTemplate For<T>() where T : class;
    }
}
