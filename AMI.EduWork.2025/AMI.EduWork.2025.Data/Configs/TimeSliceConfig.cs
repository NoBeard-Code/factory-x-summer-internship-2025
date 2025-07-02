using AMI.EduWork._2025.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Data.Configs;
public class TimeSliceConfig : IEntityTypeConfiguration<TimeSlice>
{
    public void Configure(EntityTypeBuilder<TimeSlice> builder)
    {
        builder.Property(ts => ts.WorkDayId).IsRequired();
        builder.Property(ts => ts.Start).IsRequired();
        builder.Property(ts => ts.End).IsRequired();
        builder.Property(ts => ts.TypeOfSlice).IsRequired();
        builder.Property(ts => ts.Description).IsRequired(false);

        builder.HasOne(ts => ts.WorkDay)
            .WithMany(wd => wd.TimeSlices)
            .HasForeignKey(ts => ts.WorkDayId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ts => ts.Project)
            .WithMany(p => p.TimeSlices)
            .HasForeignKey(ts => ts.ProjectId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(ts => ts.User)
            .WithMany(u => u.TimeSlices)
            .HasForeignKey(ts => ts.UserId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
