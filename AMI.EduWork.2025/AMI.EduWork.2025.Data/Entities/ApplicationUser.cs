using AMI.EduWork._2025.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace AMI.EduWork._2025.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Contract> Contracts { get; set; }
        public virtual ICollection<SickLeave> SickLeaves { get; set; }
        public virtual ICollection<UserOnVacation> UsersOnVacations { get; set; }
        public virtual ICollection<UserOnProject> UsersOnProjects { get; set; }
        public virtual ICollection<WorkDay> WorkDays { get; set; }


    }

}
