﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using JsonCrafter.Configuration.Interfaces;
using JsonCrafter.Contracts.Interfaces;

namespace JsonCrafter.Contracts
{
    public class Contract : IContract
    {
        public IImmutableList<IMember> Members { get; }
        public Type ContractedType { get; }
        public ITypeTemplate Template { get; }
        public bool HasTemplate { get; }

        public Contract(Type type, ITypeTemplate template, IEnumerable<IMember> members = default(IEnumerable<IMember>))
        {
            Template = template;
            HasTemplate = template != default(ITypeTemplate);
            if(type == null || !type.IsClass || type.IsAbstract)
            {
                throw new NotSupportedException("TypeContract only supports non-abstract classes.");
            }

            ContractedType = type;
            Members = members?.ToImmutableList() ?? new List<IMember>().ToImmutableList();
        }
    }
}