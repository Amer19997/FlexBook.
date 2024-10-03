using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using FlexBook.Application.Common.Interfaces;

namespace Resources;
public static class ConfigureServices
{
    public static IServiceCollection AddResourceService(this IServiceCollection services)
    {
        services.AddSingleton<IResourceService, ResourceService>();

        return services;
    }
}
