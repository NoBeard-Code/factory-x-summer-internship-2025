©using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Data.Entities
{
    public class SickLeave
    {
        [Required]
        [Key]
        public string Id { get; set; }
        [Required]
        public DateOnly StartDate{ get; set; }
        [Required]
        public DateOnly EndDate { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; } 
        public ApplicationUser User { get; set; }

    }
}
