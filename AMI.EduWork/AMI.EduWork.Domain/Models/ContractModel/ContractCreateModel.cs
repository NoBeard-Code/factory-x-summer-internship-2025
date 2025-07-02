<<<<<<< HEAD:AMI.EduWork.2025/AMI.EduWork.2025.Domain/Models/ContractModel/ContractCreateModel.cs
﻿namespace AMI.EduWork._2025.Domain.Models.ContractModel
=======
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork.Domain.Models.ContractModel
>>>>>>> main:AMI.EduWork/AMI.EduWork.Domain/Models/ContractModel/ContractCreateModel.cs
{
    public class ContractCreateModel
    {
        public int WorkingHour { get; set; }
        public DateOnly Created {  get; set; }
        public bool IsActive { get; set; }
        public int HourlyRate { get; set; }
        public string UserId{ get; set; }
    }
}
