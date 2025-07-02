using AMI.EduWork.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork.Data.Configs;
public class VacationConfig : IEntityTypeConfiguration<Vacation>
{
    public void Configure(EntityTypeBuilder<Vacation> builder)
    {
        builder.Property(uov => uov.AnnualVacationId).IsRequired();
        builder.Property(uov => uov.StartDate).IsRequired();
        builder.Property(uov => uov.EndDate).IsRequired();

        

        builder.HasOne(uov => uov.AnnualVacation)
            .WithMany(av => av.Vacations)
            .HasForeignKey(uov => uov.AnnualVacationId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
