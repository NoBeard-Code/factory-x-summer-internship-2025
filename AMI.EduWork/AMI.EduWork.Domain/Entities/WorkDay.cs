using AMI.EduWork.Domain.Entities.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork.Domain.Entities;

public class WorkDay : EntityBase
{
    [Required]
    public DateTime Date { get; set; }
    public virtual ICollection<TimeSlice> TimeSlices { get; set; }
}
