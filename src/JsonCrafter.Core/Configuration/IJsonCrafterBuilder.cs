namespace JsonCrafter.Core.Configuration
{
    public interface IJsonCrafterBuilder
    {
        void EnableMediaType(MediaType type);
        ITypeBuilder<T> For<T>() where T : class;
    }
}
