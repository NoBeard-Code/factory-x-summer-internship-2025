using AMI.EduWork.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace AMI.EduWork.Domain;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public virtual byte Role { get; set; }
    public virtual ICollection<Contract> Contracts { get; set; }
    public virtual ICollection<SickLeave> SickLeaves { get; set; }
    public virtual ICollection<AnnualVacation> AnnualVacations { get; set; }
    public virtual ICollection<UserOnProject> UsersOnProjects { get; set; }
    public virtual ICollection<TimeSlice>? TimeSlices { get; set; }


}
