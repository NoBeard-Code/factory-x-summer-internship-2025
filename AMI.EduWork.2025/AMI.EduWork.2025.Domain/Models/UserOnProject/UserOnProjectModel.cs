using AMI.EduWork._2025.Domain.Models.Project;
using AMI.EduWork._2025.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Domain.Models.UserOnProject {
    public class UserOnProjectModel {
        public required string UserId { get; set; }
        public required string ProjectId { get; set; }
        public required string ProjectRole { get; set; }
        public DateTime RoleStartDate { get; set; }
        public DateTime RoleEndDate { get; set; }
    }

    public class GetUserOnProjectModel : UserOnProjectModel {
        public string Id { get; set; } = default!;
        public required GetUserModel User { get; set; }
        public required GetProjectModel Project { get; set; }
    }


}
