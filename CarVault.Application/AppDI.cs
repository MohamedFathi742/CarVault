using CarVault.Application.Mapping;
using CarVault.Application.Validatores;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace CarVault.Application;
public static class AppDI
{
    public static IServiceCollection AddApplication(this IServiceCollection services) 
    {


        services.AddValidatorsFromAssemblyContaining<RegisterUserRequestValidator>();

        MappingConfiguration.RegisterMappings();

        return services;


    }

}
