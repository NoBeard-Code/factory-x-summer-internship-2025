using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Data.Entities
{
    public class UserOnProject
    {
        [Required]
        [Key]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        [Required]
        [Key]
        public string ProjectId { get; set; }
        public Project Project{ get; set; }
        [Required]
        public string ProjectRole { get; set; }
        [Required]
        public DateTime RoleStartDate { get; set; }
        [Required]
        public DateTime RoleEndDate { get; set; }
    }
}
