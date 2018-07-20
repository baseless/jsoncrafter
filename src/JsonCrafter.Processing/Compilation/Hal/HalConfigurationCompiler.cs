using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using JsonCrafter.Core;
using JsonCrafter.Core.Exceptions;
using JsonCrafter.Core.Helpers;
using JsonCrafter.Processing.Configuration;
using JsonCrafter.Processing.Contracts;
using JsonCrafter.Processing.Contracts.Items;
using JsonCrafter.Processing.Naming;
using Microsoft.EntityFrameworkCore.Internal;
using TypeContract = JsonCrafter.Processing.Contracts.Items.TypeContract;

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
        public ITypeContractResolver Compile()
        {
            Ensure.IsSet(Resources);
            var contracts = new Dictionary<Type, IJsonContract>();

            foreach (var typeResources in Resources)
            {
                ValidateResource(typeResources.Key, typeResources.Value);
                
                // todo: BUILD - contract assembly

                var contract = CompileType(typeResources.Key, typeResources, out var relatedTypes);
                contracts.Add(typeResources.Key, contract);
            }
            
            return new TypeContractResolver(contracts);
        }

        private void ValidateResource(Type type, IResource resource)
        {
            //todo: VALIDATE - that the number of params, and the param names matches the param list for links.
            // todo: VALIDATE - that the formatspecific parts are entered. For example JsonAPI requires ID.
            // todo: VALIDATE - that embedded resources are actually contracted with For<>() temselves.
            // todo: VALIDATE - how to handle if a selected parameter property turns out to be null?

        }

        private IJsonContract CompileType(Type type, KeyValuePair<Type, IResource> resource, out ICollection<Type> relatedTypes)
        {
            var str = typeof(string);
            var m2 = str.GetPublicMembers();
            relatedTypes = new List<Type>();

            var children = new List<KeyValuePair<string, IJsonContract>>();

            var typeMembers = resource.Key.GetPublicMembers();
            foreach (var mbr in typeMembers)
            {
                var info = mbr.GetValueInfo();

                if (info == null)
                {
                    continue;
                }

                if (info.MemberType.IsAnyCollection())
                {
                    children.Add(new KeyValuePair<string, IJsonContract>(_caseFormatter.Format(info.Name), new ReferredListContract()));
                }
                else if (info.MemberType.IsSingleObject())
                {
                    relatedTypes.Add(info.MemberType);
                    children.Add(new KeyValuePair<string, IJsonContract>(_caseFormatter.Format(info.Name), new ReferredTypeContract()));
                }
                else if (info.MemberType.IsSimple())
                {
                    children.Add(new KeyValuePair<string, IJsonContract>(_caseFormatter.Format(mbr.Name), new PropertyContract(info)));
                }
            }
            return new TypeContract(children);

        }
    }
}
