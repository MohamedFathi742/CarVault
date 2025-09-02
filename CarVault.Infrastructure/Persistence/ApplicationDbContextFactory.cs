using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarVault.Infrastructure.Persistence;
public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
       var optionsBulder=new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBulder.UseSqlServer("Server=.;Database=CarVaultDb;Trusted_Connection=True;TrustServerCertificate=True;");
        return new ApplicationDbContext(optionsBulder.Options);
    }
}
