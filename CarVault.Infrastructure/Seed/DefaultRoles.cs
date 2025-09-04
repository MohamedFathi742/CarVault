using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarVault.Infrastructure.Seed;
public class DefaultRoles
{
    public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
    {
        if (! await roleManager.RoleExistsAsync("Admin"))
        
           await roleManager.CreateAsync(new IdentityRole("Admin"));
        
        if (! await roleManager.RoleExistsAsync("Seller"))
        
           await roleManager.CreateAsync(new IdentityRole("Seller"));
        
        if (! await roleManager.RoleExistsAsync("User"))
        
           await roleManager.CreateAsync(new IdentityRole("User"));
        


    }

}
