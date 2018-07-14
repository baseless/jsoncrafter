﻿using System;
using System.Reflection;
using JsonCrafter.Core.Helpers;

namespace JsonCrafter.Core.Contracts
{
    public abstract class MemberContractBase<TInfo> : IMemberContract where TInfo: MemberInfo
    {
        protected TInfo Info { get; }
        public bool IsResource { get; }
        public bool IsValue { get; }
        public bool IsCollection { get; }

        protected MemberContractBase(string name, TInfo info, bool isResource, Type targetType)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Info = info ?? throw new ArgumentNullException(nameof(info));

            IsResource = isResource;
            IsValue = TypeHelper.IsValue(targetType);
            IsCollection = TypeHelper.IsCollection(targetType);
        }

        public abstract object GetValueFromObject(object obj);

        public string Name { get; }
    }
}
