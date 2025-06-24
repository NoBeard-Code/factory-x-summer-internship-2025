using AMI.EduWork._2025.Domain.Entities.Abstraction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Domain.Entities;

public class UserOnProject : EntityBase
{
    [Required]
    [ForeignKey(nameof(UserId))]
    public string UserId { get; set; }
    public virtual ApplicationUser User { get; set; }
    [Required]
    [ForeignKey(nameof(ProjectId))]
    public string ProjectId { get; set; }
    public virtual Project Project{ get; set; }
    [Required]
    public string ProjectRole { get; set; }
    [Required]
    public DateTime RoleStartDate { get; set; }
    [Required]
    public DateTime RoleEndDate { get; set; }
}
