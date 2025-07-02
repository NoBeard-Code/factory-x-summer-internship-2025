using AMI.EduWork.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork.Data.Configs;

public class ProjectConfig : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.Property(p => p.Name).IsRequired();
        builder.Property(p => p.TypeOfProject).IsRequired();
        builder.Property(p => p.Description).IsRequired();

        builder.HasMany(p => p.TimeSlices)
            .WithOne(ts => ts.Project)
            .HasForeignKey(ts => ts.ProjectId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(p => p.UsersOnProjects)
            .WithOne(uop => uop.Project)
            .HasForeignKey(uop => uop.ProjectId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
