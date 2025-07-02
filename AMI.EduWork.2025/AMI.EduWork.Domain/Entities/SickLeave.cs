using AMI.EduWork.Domain.Entities.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork.Domain.Entities;

public class SickLeave : EntityBase
{
    [Required]
    public DateOnly StartDate{ get; set; }
    [Required]
    public DateOnly EndDate { get; set; }
    [Required]
    public int Year { get; set; }
    [Required]
    [ForeignKey(nameof(UserId))]
    public string UserId { get; set; } 
    public virtual ApplicationUser User { get; set; }

}
