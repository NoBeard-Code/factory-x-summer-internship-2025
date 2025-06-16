using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Data.Entities
{
    public class Project
    {
        [Required]
        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public byte TypeOfProject { get; set; }
        [Required]
        public string Description { get; set; }
        ICollection<TimeSlice> TimeSlices { get; set; }
        ICollection<UserOnProject> UsersOnProjects { get; set; }

    }
}
