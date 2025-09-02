using CarVault.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarVault.Infrastructure.Persistence.Configurations;
public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);

        builder.Property(o => o.OrderDate)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(o => o.Status)
            .IsRequired()
            .HasDefaultValue("Pending");

        builder.HasOne(o=>o.User)
            .WithMany(o=>o.Orders)
            .HasForeignKey(o=>o.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(o => o.Car)
            .WithOne(o => o.Order)
            .HasForeignKey<Order>(o => o.CarId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
