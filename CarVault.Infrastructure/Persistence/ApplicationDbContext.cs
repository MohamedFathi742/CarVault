﻿using CarVault.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarVault.Infrastructure.Persistence;
public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
public DbSet<Car> Cars { get; set; }
public DbSet<Order>  Orders { get; set; }
public DbSet<Category>  Categories { get; set; }
public DbSet<CarImage>  CarImages { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

}
