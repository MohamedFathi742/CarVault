using CarVault.Domain.Entities;
using CarVault.Infrastructure.Persistence;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarVault.Infrastructure;
public static class DI
{

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString, IConfiguration configuration)
    {

        services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(connectionString));

        services.AddIdentity<ApplicationUser,IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();



        services.AddValidatorsFromAssembly(typeof(DI).Assembly);

        return services;
    }

}
