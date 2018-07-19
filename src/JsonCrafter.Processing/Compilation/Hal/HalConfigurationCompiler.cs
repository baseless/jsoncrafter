using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JsonCrafter.Core;
using JsonCrafter.Processing.Configuration;
using JsonCrafter.Processing.Contracts;
using JsonCrafter.Processing.Naming;

namespace JsonCrafter.Processing.Compilation.Hal
{
    public sealed class HalConfigurationCompiler : ConfigurationBuilderBase, IHalConfigurationCompiler
    {
        private readonly ICaseFormatter _caseFormatter;

        public HalConfigurationCompiler(ICaseFormatter caseFormatter, IConfigurationAction action)
        {
            Ensure.IsSet(action);
            action.Invoke(this);
            _caseFormatter = Ensure.IsSet(caseFormatter);
        }
        

        [MethodImpl(MethodImplOptions.Synchronized)]
        public IResourceContractResolver Compile()
        {
            Ensure.IsSet(Resources);
            var contracts = new Dictionary<Type, IResourceContract>();

            foreach (var typeResources in Resources)
            {
                ValidateResource(typeResources.Key, typeResources.Value);
                
                // todo: BUILD - contract assembly
                
                contracts.Add(typeResources.Key, new ResourceContract());
            }
            
            return new ResourceContractResolver(contracts);
        }

        private void ValidateResource(Type type, IResource resource)
        {
            //todo: VALIDATE - that the number of params, and the param names matches the param list for links.
            // todo: VALIDATE - that the formatspecific parts are entered. For example JsonAPI requires ID.
            // todo: VALIDATE - that embedded resources are actually contracted with For<>() temselves.
            // todo: VALIDATE - how to handle if a selected parameter property turns out to be null?

        }

        private void BuildLinksObject()
        {

        }

        private void BuildDataObject()
        {

        }
    }
}
