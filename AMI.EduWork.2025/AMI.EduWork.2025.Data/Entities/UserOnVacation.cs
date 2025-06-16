using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Data.Entities
{
    [PrimaryKey(nameof(UserId), nameof(AnnualVacationId))]
    public class UserOnVacation 
    {
        [Required]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        [Required]
        public string AnnualVacationId { get; set; }
        public AnnualVacation AnnualVacation { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }

    }
}
