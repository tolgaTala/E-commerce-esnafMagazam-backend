﻿using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{
    public static class ServicesCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollecttion, ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(serviceCollecttion);
            }
            return ServiceTool.Create(serviceCollecttion);
        }
    }
}
