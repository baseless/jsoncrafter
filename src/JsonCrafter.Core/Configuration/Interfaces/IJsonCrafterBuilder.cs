namespace JsonCrafter.Core.Configuration.Interfaces
{
    public interface IJsonCrafterBuilder
    {
        void EnableMediaType(MediaType type);
        ITypeBuilder<T> For<T>() where T : class;
    }
}
