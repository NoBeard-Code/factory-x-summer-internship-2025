<<<<<<< HEAD:AMI.EduWork.2025/AMI.EduWork.2025.Domain/Entities/Contract.cs
﻿using AMI.EduWork._2025.Domain.Entities.Abstraction;
=======
﻿using AMI.EduWork.Domain.Entities.Abstraction;
using System;
using System.Collections.Generic;
>>>>>>> main:AMI.EduWork/AMI.EduWork.Domain/Entities/Contract.cs
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
