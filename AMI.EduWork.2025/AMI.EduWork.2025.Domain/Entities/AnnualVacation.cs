using AMI.EduWork._2025.Domain.Entities.Abstraction;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
    [Required]
    [ForeignKey(nameof(UserId))]
    public string UserId { get; set; }
    public virtual ApplicationUser User { get; set; }
    public virtual ICollection<Vacation> Vacations { get; set; }

}
