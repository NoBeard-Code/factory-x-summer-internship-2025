using AMI.EduWork.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork.Domain.Models.ContractModel
{
    public class ContractGetModel
    {
        public string Id { get; set; }
        public int WorkingHour { get; set; }
        public bool IsActive { get; set; }
        public int HourlyRate { get; set; }
        public GetUserModel _GetUserModel { get; set; }
    }
}
