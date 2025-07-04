﻿using AMI.EduWork.Domain.Entities.Abstraction;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMI.EduWork.Domain.Entities;

public class Contract : EntityBase
{
    [Required]
    public int WorkingHour { get; set; }
    [Required]
    public DateOnly Created { get; set; }
    [Required]
    public bool IsActive { get; set; }
    [Required]
    public int HourlyRate { get; set; }
    [Required]
    [ForeignKey(nameof(UserId))]
    public string UserId { get; set; }
    public virtual ApplicationUser User { get; set; }
}
