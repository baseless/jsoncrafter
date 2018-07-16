﻿using System;
using System.Linq.Expressions;
using JsonCrafter.Serialization.Build;
using JsonCrafter.Shared.Enums;
using Microsoft.AspNetCore.Mvc;

namespace JsonCrafter.Serialization.Configuration
{
    public interface IJsonCrafterConfigurator
    {
        void EnableMediaType(JsonCrafterMediaType type);
        IResourceConfigurator<TResource> For<TResource>(Expression<Func<IUrlHelper, string>> url, params Expression<Func<TResource, object>>[] values) where TResource : class;
    }
}