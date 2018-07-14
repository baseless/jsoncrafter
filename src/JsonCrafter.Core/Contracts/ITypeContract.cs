﻿using System;
using System.Collections.Immutable;
using JsonCrafter.Core.Configuration;

namespace JsonCrafter.Core.Contracts
{
    public interface ITypeContract
    {
        IImmutableList<IMemberContract> Members { get; }
        Type ContractedType { get; }

        ITypeContractTemplate Template { get; }
        bool HasTemplate { get; }
    }
}
