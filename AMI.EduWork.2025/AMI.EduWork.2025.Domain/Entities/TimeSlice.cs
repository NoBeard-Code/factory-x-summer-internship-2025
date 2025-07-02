using AMI.EduWork._2025.Domain.Entities.Abstraction;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Domain.Entities;

public class TimeSlice : EntityBase
{
    [Required]
    [ForeignKey(nameof(WorkDayId))]
    public string WorkDayId { get; set; }
    public virtual WorkDay WorkDay { get; set; }
    [AllowNull]
    [ForeignKey(nameof(ProjectId))]
    public string ProjectId { get; set; }
    public virtual Project Project { get; set; }
    [Required]
    public DateTime Start { get; set; }
    [Required]
    public DateTime End { get; set; }
    [Required]
    public byte TypeOfSlice {  get; set; }
    [AllowNull]
    [ForeignKey(nameof(UserId))]
    public string? UserId { get; set; }
    public virtual ApplicationUser? User { get; set; }
    [AllowNull]
    public string? Description { get; set; }
}
