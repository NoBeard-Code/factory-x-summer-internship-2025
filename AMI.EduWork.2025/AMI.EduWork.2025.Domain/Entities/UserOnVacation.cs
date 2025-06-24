using AMI.EduWork._2025.Domain.Entities.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Domain.Entities;

public class UserOnVacation : EntityBase
{
    [Required]
    [ForeignKey(nameof(UserId))]
    public string UserId { get; set; }
    public ApplicationUser User { get; set; }
    [Required]
    [ForeignKey(nameof(AnnualVacationId))]
    public string AnnualVacationId { get; set; }
    public virtual AnnualVacation AnnualVacation { get; set; }
    [Required]
    public DateTime StartDate { get; set; }
    [Required]
    public DateTime EndDate { get; set; }

}
