﻿using AMI.EduWork.Domain.Entities.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork.Domain.Entities;

public class Project : EntityBase
{
    [Required]
    public string Name { get; set; }
    [Required]
    public byte TypeOfProject { get; set; }
    [Required]
    public string Description { get; set; }
    public virtual ICollection<TimeSlice> TimeSlices { get; set; } = new List<TimeSlice>();
    public virtual ICollection<UserOnProject> UsersOnProjects { get; set; } = new List<UserOnProject>();

}
