<<<<<<< HEAD:AMI.EduWork.2025/AMI.EduWork.2025.Domain/Models/ContractModel/ContractGetModel.cs
﻿using AMI.EduWork._2025.Domain.Models.User;
=======
﻿using AMI.EduWork.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
>>>>>>> main:AMI.EduWork/AMI.EduWork.Domain/Models/ContractModel/ContractGetModel.cs

namespace AMI.EduWork.Domain.Models.ContractModel
{
    public class ContractGetModel
    {
        public string Id { get; set; }
        public DateOnly Created {  get; set; }
        public int WorkingHour { get; set; }
        public bool IsActive { get; set; }
        public int HourlyRate { get; set; }
        public GetUserModel _GetUserModel { get; set; }
    }
}
