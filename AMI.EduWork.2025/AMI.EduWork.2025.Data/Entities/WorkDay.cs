using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Data.Entities
{
    public class WorkDay
    {
        [Required]
        [Key]
        public string Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public ICollection<ApplicationUser> Users { get; set; }
        public ICollection<TimeSlice> TimeSlices { get; set; }
    }
}
