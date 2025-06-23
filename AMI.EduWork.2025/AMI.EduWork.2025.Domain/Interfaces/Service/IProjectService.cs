using AMI.EduWork._2025.Domain.Entities;
using AMI.EduWork._2025.Domain.Models.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Domain.Interfaces.Service {
    public interface IProjectService {
        Task Create(ProjectModel model);
        Task Update(string projectId, ProjectModel model);
        Task Delete(string projectId);

        Task<GetProjectModel> GetById(string projectId);
        Task<GetProjectModel> GetProjectByName(string name);
        Task<IEnumerable<GetProjectModel>> GetAllProjectsByUserId(string userId);
        Task<IEnumerable<GetProjectModel>> GetProjectsByDateRange(DateTime startDate, DateTime endDate);

        Task<bool> ProjectExists(string name);
    }

}
