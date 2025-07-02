using AMI.EduWork.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork.Domain.Models.SickLeave {
    public class SickLeaveModel {
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int Year { get; set; }
        public required string UserId { get; set; }
    }

    public class GetSickLeaveModel : SickLeaveModel {
        public string Id { get; set; } = default!;
        public required GetUserModel User { get; set; }
    }

}
