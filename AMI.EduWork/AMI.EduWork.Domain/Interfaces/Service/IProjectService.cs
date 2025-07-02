using AMI.EduWork.Domain.Entities;
using AMI.EduWork.Domain.Models.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork.Domain.Interfaces.Service {
    public interface IProjectService {
        Task Create(ProjectModel model);
        Task Update(string projectId, ProjectModel model);
        Task Delete(string projectId);

        Task<GetProjectModel> GetById(string projectId);
        Task<GetProjectModel> GetProjectByName(string name);
        Task<IEnumerable<GetProjectModel>> GetProjectsByDateRange(DateTime startDate, DateTime endDate);
        Task<IEnumerable<GetProjectModel>> GetAllUserProjects(string userId);

        Task<bool> ProjectExists(string name);
    }

}
