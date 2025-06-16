using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Data.Entities
{
    public class UsersOnVacation
    {
        [Required]
        [Key]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        [Required]
        [Key]
        public string AnnualVacationId { get; set; }
        public AnnualVacation AnnualVacation { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }

    }
}
