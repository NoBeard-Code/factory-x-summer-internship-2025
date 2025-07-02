using AMI.EduWork.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork.Data.Configs;
public class ApplicationUserConfig : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(au => au.Role).IsRequired();

        builder.HasMany(au => au.Contracts)
            .WithOne(c => c.User)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(au => au.SickLeaves)
            .WithOne(sl => sl.User)
            .HasForeignKey(sl => sl.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(au => au.AnnualVacations)
            .WithOne(uov => uov.User)
            .HasForeignKey(uov => uov.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(au => au.AnnualVacations)
            .WithOne(uop => uop.User)
            .HasForeignKey(uop => uop.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(au => au.TimeSlices)
            .WithOne(ts => ts.User)
            .HasForeignKey(ts => ts.UserId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
