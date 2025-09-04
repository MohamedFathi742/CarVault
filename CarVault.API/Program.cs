
using CarVault.Application;
using CarVault.Infrastructure;
using CarVault.Infrastructure.Seed;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace CarVault.API;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddApplication();
        builder.Services.AddInfrastructure(
            builder.Configuration.GetConnectionString("DefaultConnection")!,
            builder.Configuration
        );




        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddSwaggerGen(c =>
        {
            c.EnableAnnotations(); 
        });
        var app = builder.Build();
        using (var scope= app.Services.CreateScope()) 
        {
            var roleManger = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        await DefaultRoles.SeedRolesAsync(roleManger);
        }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
