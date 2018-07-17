using JsonCrafter.Processing.Contracts;

namespace JsonCrafter.Processing.Compilation
{
    public interface ISettingsCompiler
    {
        IResourceContractResolver Compile();
    }
}
