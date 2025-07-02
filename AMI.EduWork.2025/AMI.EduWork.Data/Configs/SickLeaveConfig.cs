using AMI.EduWork.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork.Data.Configs;

public class SickLeaveConfig: IEntityTypeConfiguration<SickLeave>
{
    public void Configure(EntityTypeBuilder<SickLeave> builder)
    {
        builder.Property(sl => sl.StartDate).IsRequired();
        builder.Property(sl => sl.EndDate).IsRequired();
        builder.Property(sl => sl.Year).IsRequired();
        builder.Property(sl => sl.UserId).IsRequired();

        builder.HasOne(sl => sl.User)
            .WithMany(u => u.SickLeaves)
            .HasForeignKey(sl => sl.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
