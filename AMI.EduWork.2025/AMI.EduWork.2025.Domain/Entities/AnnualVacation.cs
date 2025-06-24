using AMI.EduWork._2025.Domain.Entities.Abstraction;
using System.ComponentModel.DataAnnotations;

namespace AMI.EduWork._2025.Domain.Entities;

public class AnnualVacation : EntityBase
{
    [Required]
    public int UsedVacation { get; set; }
    [Required]
    public int Year { get; set; }
    [Required]
    public int PlannedVacation { get; set; }
    [Required]
    public int AvailableVacation { get; set; }
    public virtual ICollection<UserOnVacation> UsersOnVacations { get; set; }

}
