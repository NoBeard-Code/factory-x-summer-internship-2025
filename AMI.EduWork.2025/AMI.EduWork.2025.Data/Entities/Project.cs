using AMI.EduWork._2025.Data.Entities.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Data.Entities
{
    public class Project : EntityBase
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public byte TypeOfProject { get; set; }
        [Required]
        public string Description { get; set; }
        public virtual ICollection<TimeSlice> TimeSlices { get; set; }
        public virtual ICollection<UserOnProject> UsersOnProjects { get; set; }

    }
}
