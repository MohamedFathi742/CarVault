using CarVault.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarVault.Infrastructure.Persistence.Configurations;
public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
      builder.HasKey(c => c.Id);
       
        builder.Property(c => c.Model)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.Brand)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.Price)
           .HasColumnType("decimal(18,2)");

        builder.Property(c => c.IsSold)
           .HasDefaultValue(false);

        builder.HasOne(c=>c.Category)
            .WithMany(ca=>ca.Cars)
            .HasForeignKey(c=>c.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);  

        builder.HasOne(c=>c.User)
            .WithMany(ca=>ca.Cars)
            .HasForeignKey(c=>c.UserId)
            .OnDelete(DeleteBehavior.SetNull);  

        builder.HasOne(c=>c.Order)
            .WithOne(o=>o.Car)
            .HasForeignKey<Order>(o=>o.CarId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c=>c.CarImages)
            .WithOne(im=>im.Car)
            .HasForeignKey(im=>im.CarId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}
