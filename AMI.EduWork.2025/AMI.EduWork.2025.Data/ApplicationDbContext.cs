using AMI.EduWork._2025.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AMI.EduWork._2025.Data
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {

        }

        public DbSet<AnnualVacation> AnnualVacations { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<SickLeave> SickLeaves { get; set; }
        public DbSet<TimeSlice> TimeSlices { get; set; }
        public DbSet<UserOnProject> UsersOnProjects { get; set; }
        public DbSet<UserOnVacation> UsersOnVacations { get; set; }
        public DbSet<WorkDay> WorkDays { get; set; }
    }
}
