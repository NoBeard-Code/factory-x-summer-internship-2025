using AMI.EduWork._2025.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Data.Configs;

// Contract Configuration
public class ContractConfig : IEntityTypeConfiguration<Contract>
{
    public void Configure(EntityTypeBuilder<Contract> builder)
    {
        builder.Property(c => c.WorkingHour).IsRequired();
        builder.Property(c => c.IsActive).IsRequired();
        builder.Property(c => c.HourlyRate).IsRequired();
        builder.Property(c => c.UserId).IsRequired();

        builder.HasOne(c => c.User)
            .WithMany(u => u.Contracts)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
