using JsonCrafter.Processing.Configuration;

namespace JsonCrafter.Processing.Compilation
{
    public interface IConfigurationAction
    {
        void Invoke(IConfigurationBuilder configurator);
    }
}
