using CarVault.Application;
using CarVault.Application.Interfaces;
using CarVault.Application.Interfaces.Security;
using CarVault.Application.Services;
using CarVault.Application.Validatores;
using CarVault.Domain.Entities;
using CarVault.Infrastructure.Persistence;
using CarVault.Infrastructure.Repositories;
using CarVault.Infrastructure.Security;
using CarVault.Infrastructure.Services;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CarVault.Infrastructure;
public static class InfraDI
{

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString, IConfiguration configuration)
    {

        services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(connectionString));

        services.AddIdentity<ApplicationUser,IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();


        var jwtSettings = configuration.GetSection("JWT");
        var key=Encoding.UTF8.GetBytes(jwtSettings["Key"]!);
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;



        }).AddJwtBearer(options => 
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
              
                ValidIssuer = jwtSettings["Issuer"],
                ValidAudience = jwtSettings["Audience"],
                IssuerSigningKey=new SymmetricSecurityKey(key)

            };
           });


        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<ICarRepository, CarRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICarImageRepository, CarImageRepository>();
        services.AddScoped<ICarService, CarService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<ICarImageService, CarImageService>();
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ICarImageService, CarImageService>();
        services.AddScoped<IFileStorageService, FileStorageService>();

     //   services.AddValidatorsFromAssembly(typeof(InfraDI).Assembly);


        return services;
    }

}
