using JsonCrafter.Processing.Contracts;

namespace JsonCrafter.Processing.Compilation
{
    public interface IConfigurationCompiler
    {
        IResourceContractResolver Compile();
    }
}
