namespace JsonCrafter.Configuration
{
    public interface IJsonCrafterConfiguratorAction
    {
        void Invoke(IJsonCrafterConfigurator configurator);
    }
}
