using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Domain.Models.ContractModel
{
    public class ContractGetByIdModel
    {
        public string Id { get; set; }
        public int WorkingHour { get; set; }
        public bool IsActive { get; set; }
        public int HourlyRate { get; set; }
        //public UserGetByIdModel userGetByIdModel { get; set; }
    }
}
