using System.Runtime.CompilerServices;
using JsonCrafter.Core;
using JsonCrafter.Processing.Configuration;
using JsonCrafter.Processing.Contracts;
using JsonCrafter.Processing.Naming;

namespace JsonCrafter.Processing.Compilation.Hal
{
    public class HalConfigurationCompiler : ConfigurationBuilderBase, IHalConfigurationCompiler
    {
        private readonly ICaseFormatter _caseFormatter;

        public HalConfigurationCompiler(ICaseFormatter caseFormatter)
        {
            _caseFormatter = Ensure.IsSet(caseFormatter);
        }
        

        [MethodImpl(MethodImplOptions.Synchronized)] // todo: needed?
        public IResourceContractResolver Compile()
        {
            var test = _caseFormatter.Format("HalleDUDANeMej");
            // 1. Validate all resource setting based on hal rules
            // 2. Build all related
            // 3. Build and return resolver
            return new ResourceContractResolver();
        }
    }
}
