using JsonCrafter.Processing.Contracts;

namespace JsonCrafter.Processing.Compilation
{
    public interface IConfigurationCompiler
    {
        ITypeContractResolver Compile();
    }
}
