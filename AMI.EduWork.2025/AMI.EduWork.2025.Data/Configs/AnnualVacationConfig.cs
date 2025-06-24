using AMI.EduWork._2025.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Data.Configs;

public class AnnualVacationConfig : IEntityTypeConfiguration<AnnualVacation>
{
    public void Configure(EntityTypeBuilder<AnnualVacation> builder)
    {
        builder.Property(av => av.UsedVacation)
            .IsRequired();

        builder.Property(av => av.Year)
            .IsRequired();

        builder.Property(av => av.PlannedVacation)
            .IsRequired();

        builder.Property(av => av.AvailableVacation)
            .IsRequired();

        builder.HasMany(av => av.UsersOnVacations)
            .WithOne() 
            .IsRequired(false); 
    }
}
