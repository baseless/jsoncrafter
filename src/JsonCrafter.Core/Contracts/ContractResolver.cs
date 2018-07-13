using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace JsonCrafter.Core.Contracts
{
    public class ContractResolver : IContractResolver
    {
        private static readonly ConcurrentDictionary<Type, ITypeContract> Contracts = new ConcurrentDictionary<Type, ITypeContract>();
        
        public ITypeContract Resolve(Type type)
        {
            return CreateContract(type);
            return Contracts.GetOrAdd(type, CreateContract);
        }

        internal ITypeContract CreateContract(Type type)
        {
            var fields = CreateFieldContracts(type);
            return new TypeContract(type, fields);
        }

        internal IDictionary<string, IFieldContract> CreateFieldContracts(Type type)
        {
            const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;

            type.GetFields(flags);
            var properties = type.GetProperties(flags);

            return type
                .GetFields()
                .ToDictionary<FieldInfo, string, IFieldContract>(field => field.Name, field => new FieldContract(field.Name, field));
        }
    }
}
