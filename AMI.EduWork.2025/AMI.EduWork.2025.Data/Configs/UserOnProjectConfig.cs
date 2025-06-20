using AMI.EduWork._2025.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Data.Configs;
public class UserOnProjectConfig : IEntityTypeConfiguration<UserOnProject>
{
    public void Configure(EntityTypeBuilder<UserOnProject> builder)
    {
        builder.Property(uop => uop.UserId).IsRequired();
        builder.Property(uop => uop.ProjectId).IsRequired();
        builder.Property(uop => uop.ProjectRole).IsRequired();
        builder.Property(uop => uop.RoleStartDate).IsRequired();
        builder.Property(uop => uop.RoleEndDate).IsRequired();

        builder.HasOne(uop => uop.User)
            .WithMany(u => u.UsersOnProjects)
            .HasForeignKey(uop => uop.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(uop => uop.Project)
            .WithMany(p => p.UsersOnProjects)
            .HasForeignKey(uop => uop.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
