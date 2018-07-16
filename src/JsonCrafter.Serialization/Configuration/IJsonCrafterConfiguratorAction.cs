namespace JsonCrafter.Serialization.Configuration
{
    public interface IJsonCrafterConfiguratorAction
    {
        void Invoke(IJsonCrafterConfigurator configurator);
    }
}
