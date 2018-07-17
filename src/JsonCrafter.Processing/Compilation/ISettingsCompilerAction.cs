using JsonCrafter.Processing.Configuration;

namespace JsonCrafter.Processing.Compilation
{
    public interface ISettingsCompilerAction
    {
        void Invoke(IConfigurationBuilder configurator);
    }
}
