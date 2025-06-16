using AMI.EduWork._2025.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics.Contracts;

namespace AMI.EduWork._2025.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Entities.Contract> Contracts { get; set; }
        public ICollection<SickLeave> SickLeaves { get; set; }
        public ICollection<UserOnVacation> UsersOnVacations { get; set; }
        public ICollection<UserOnProject> UsersOnProjects { get; set; }
        public ICollection<WorkDay> WorkDays { get; set; }


    }

}
