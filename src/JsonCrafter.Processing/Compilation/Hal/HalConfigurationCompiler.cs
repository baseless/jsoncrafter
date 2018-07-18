using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JsonCrafter.Core;
using JsonCrafter.Processing.Configuration;
using JsonCrafter.Processing.Contracts;
using JsonCrafter.Processing.Naming;
using Newtonsoft.Json.Linq;

namespace JsonCrafter.Processing.Compilation.Hal
{
    public sealed class HalConfigurationCompiler : ConfigurationBuilderBase, IHalConfigurationCompiler
    {
        private readonly ICaseFormatter _caseFormatter;

        public HalConfigurationCompiler(ICaseFormatter caseFormatter)
        {
            _caseFormatter = Ensure.IsSet(caseFormatter);
        }
        

        [MethodImpl(MethodImplOptions.Synchronized)] // todo: needed?
        public IResourceContractResolver Compile()
        {
            Ensure.IsSet(Resources);
            var contracts = new Dictionary<Type, IResourceContract>();

            foreach (var typeResources in Resources)
            {
                ValidateResource(typeResources.Key, typeResources.Value);
                
                // Build contract parts
                
                contracts.Add(typeResources.Key, new ResourceContract());
            }
            
            return new ResourceContractResolver(contracts);
        }

        private void ValidateResource(Type type, IResource resource)
        {
            
        }

        private void BuildLinksObject()
        {

        }

        private void BuildDataObject()
        {

        }
    }
}
