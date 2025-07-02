using AMI.EduWork.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork.Data.Configs;

public class WorkDayConfig : IEntityTypeConfiguration<WorkDay>
{
    public void Configure(EntityTypeBuilder<WorkDay> builder)
    {
        builder.Property(wd => wd.Date).IsRequired();

        builder.HasMany(wd => wd.TimeSlices)
            .WithOne(ts => ts.WorkDay)
            .HasForeignKey(ts => ts.WorkDayId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
