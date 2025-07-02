<<<<<<< HEAD:AMI.EduWork.2025/AMI.EduWork.2025.Domain/Models/ContractModel/ContractUpdateModel.cs
﻿namespace AMI.EduWork._2025.Domain.Models.ContractModel
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork.Domain.Models.ContractModel
>>>>>>> main:AMI.EduWork/AMI.EduWork.Domain/Models/ContractModel/ContractUpdateModel.cs
{
    public class ContractUpdateModel
    {
        public string Id { get; set; }
        public int WorkingHour { get; set; }
        public DateOnly Created { get; set; }
        public bool IsActive { get; set; }
        public int HourlyRate { get; set; }
        public string UserId { get; set; }
    }
}
