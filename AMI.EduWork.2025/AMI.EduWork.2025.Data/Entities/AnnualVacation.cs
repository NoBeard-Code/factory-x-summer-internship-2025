using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Data.Entities
{
    public class AnnualVacation
    {
        [Required]
        [Key]
        public string Id { get; set; }
        [Required]
        public int UsedVacation { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public int PlannedVacation { get; set; }
        [Required]
        public int AvailableVacation { get; set; }
        ICollection<UserOnVacation> UsersOnVacations { get; set; }

    }
}
