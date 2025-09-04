using CarVault.Application.Mapping;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarVault.Application;
public static class AppDI
{
    public static IServiceCollection AddApplication(this IServiceCollection services) 
    {
        
        services.AddValidatorsFromAssembly(typeof(AppDI).Assembly);

       
        MappingConfiguration.RegisterMappings();

        return services;


    }

}
