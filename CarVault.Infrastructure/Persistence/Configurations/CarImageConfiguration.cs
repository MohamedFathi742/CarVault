using CarVault.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarVault.Infrastructure.Persistence.Configurations;
public class CarImageConfiguration : IEntityTypeConfiguration<CarImage>
{
    public void Configure(EntityTypeBuilder<CarImage> builder)
    {
        builder.HasKey(im => im.Id);

        builder.Property(im => im.ImageUrl)
            .IsRequired()
            .HasMaxLength(500)
            .HasDefaultValue("default.png");

        builder.HasOne(im => im.Car)
            .WithMany(c => c.CarImages)
            .HasForeignKey(im => im.CarId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
