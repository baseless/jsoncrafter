using System.Runtime.CompilerServices;
using JsonCrafter.Core;
using JsonCrafter.Processing.Contracts;

namespace JsonCrafter.Processing.Compilation.Hal
{
    public class HalSettingsCompiler : ConfigurationBuilderBase, IHalSettingsCompiler
    {
        private readonly ISettingsCompilerAction _configAction;

        public HalSettingsCompiler(ISettingsCompilerAction configAction)
        {
            _configAction = Ensure.IsSet(configAction);
        }
        

        [MethodImpl(MethodImplOptions.Synchronized)] // todo: needed?
        public IResourceContractResolver Compile()
        {
            // 1. Validate all resource setting based on hal rules
            // 2. Build all related
            // 3. Build and return resolver
            return new ResourceContractResolver();
        }
    }
}
