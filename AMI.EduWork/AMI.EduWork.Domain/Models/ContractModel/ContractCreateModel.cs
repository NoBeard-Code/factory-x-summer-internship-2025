using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork.Domain.Models.ContractModel
{
    public class ContractCreateModel
    {
        public int WorkingHour { get; set; }
        public bool IsActive { get; set; }
        public int HourlyRate { get; set; }
        public string UserId{ get; set; }
    }
}
