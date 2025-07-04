﻿using AMI.EduWork.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork.Data.Configs;

public class AnnualVacationConfig : IEntityTypeConfiguration<AnnualVacation>
{
    public void Configure(EntityTypeBuilder<AnnualVacation> builder)
    {
        builder.Property(uov => uov.UserId)
            .IsRequired(); 

        builder.Property(av => av.UsedVacation)
            .IsRequired();

        builder.Property(av => av.Year)
            .IsRequired();

        builder.Property(av => av.PlannedVacation)
            .IsRequired();

        builder.Property(av => av.AvailableVacation)
            .IsRequired();

        builder.HasMany(av => av.Vacations)
            .WithOne() 
            .IsRequired(false);

        builder.HasOne(uov => uov.User)
            .WithMany(u => u.AnnualVacations)
            .HasForeignKey(uov => uov.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
