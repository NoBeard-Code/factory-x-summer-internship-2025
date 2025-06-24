using AMI.EduWork._2025.Domain.Models.TimeSlice;
using AMI.EduWork._2025.Domain.Models.UserOnProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Domain.Models.Project {
    public class ProjectModel {
        public required string Name { get; set; }
        public byte TypeOfProject { get; set; }
        public required string Description { get; set; }
    }

    public class GetProjectModel : ProjectModel {
        public string Id { get; set; } = default!;
        public List<GetTimeSliceModel>? TimeSlices { get; set; }
        public List<GetUserOnProjectModel>? UsersOnProjects { get; set; }
    }
    

}
