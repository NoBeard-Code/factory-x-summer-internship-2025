using AMI.EduWork.Data.Configs;
using AMI.EduWork.Domain;
using AMI.EduWork.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace AMI.EduWork.Data
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AnnualVacationConfig());
            modelBuilder.ApplyConfiguration(new ApplicationUserConfig());
            modelBuilder.ApplyConfiguration(new ContractConfig());
            modelBuilder.ApplyConfiguration(new ProjectConfig());
            modelBuilder.ApplyConfiguration(new SickLeaveConfig());
            modelBuilder.ApplyConfiguration(new TimeSliceConfig());
            modelBuilder.ApplyConfiguration(new UserOnProjectConfig());
            modelBuilder.ApplyConfiguration(new VacationConfig());
            modelBuilder.ApplyConfiguration(new WorkDayConfig());
        }

        public DbSet<AnnualVacation> AnnualVacations { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<SickLeave> SickLeaves { get; set; }
        public DbSet<TimeSlice> TimeSlices { get; set; }
        public DbSet<UserOnProject> UsersOnProjects { get; set; }
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<WorkDay> WorkDays { get; set; }
    }
}
