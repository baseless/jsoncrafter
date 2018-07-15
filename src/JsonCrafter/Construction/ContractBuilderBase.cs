using System;
using System.Collections.Generic;
using JsonCrafter.Configuration;

namespace JsonCrafter.Construction
{
    public abstract class ContractBuilderBase
    {
        protected IDictionary<Type, IContractBuilder> Builders { get; } = new Dictionary<Type, IContractBuilder>();
        protected ICollection<MediaType> EnabledMediaTypes { get; } = new HashSet<MediaType>();

        public void EnableMediaType(MediaType type)
        {
            EnabledMediaTypes.Add(type);
        }
    }
}
