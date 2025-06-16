using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Data.Entities
{
    public class Contract
    {
        [Required]
        [Key]
        public  string Id { get; set; }
        [Required]
        public int WorkingHour { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public int HourlyRate { get; set; }
        [Required]
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
