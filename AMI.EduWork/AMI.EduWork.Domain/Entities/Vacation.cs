using AMI.EduWork.Domain.Entities.Abstraction;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMI.EduWork.Domain.Entities;

public class Vacation : EntityBase
{
    [Required]
    [ForeignKey(nameof(AnnualVacationId))]
    public string AnnualVacationId { get; set; }
    public virtual AnnualVacation AnnualVacation { get; set; }
    [Required]
    public DateOnly StartDate { get; set; }
    [Required]
    public DateOnly EndDate { get; set; }

}
