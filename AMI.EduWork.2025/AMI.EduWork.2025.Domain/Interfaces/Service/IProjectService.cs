using AMI.EduWork._2025.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Domain.Interfaces.Service {
    public interface IProjectService {

        Task Create(Project project);
        Task Update(Project project);
        Task Delete(string projectId);
        Task<Project> GetById(string projectId);
        Task<IEnumerable<Project>> GetAllProjectsByUserId(string userId);
        Task<Project> GetProjectByName(string name);
        Task<bool> ProjectExists(string name);
        Task<IEnumerable<Project>> GetProjectsByDateRange(DateTime startDate, DateTime endDate);
    }
}
