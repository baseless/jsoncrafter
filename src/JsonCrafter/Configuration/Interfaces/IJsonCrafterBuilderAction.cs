using Microsoft.AspNetCore.Mvc;

namespace JsonCrafter.Configuration.Interfaces
{
    public interface IJsonCrafterBuilderAction
    {
        void Invoke(IJsonCrafterConfigurationBuilder builder);
    }
}
