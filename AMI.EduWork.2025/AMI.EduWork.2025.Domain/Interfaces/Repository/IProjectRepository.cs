using AMI.EduWork._2025.Domain.Entities;
using AMI.EduWork._2025.Domain.IRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Domain.Interfaces.Repository {
    public interface IProjectRepository : IRepository<Project> {
        Task<Project> GetProjectByName(string name);
        Task<bool> ProjectExists(string name);
        Task<IEnumerable<Project>> GetProjectsByDateRange(DateTime startDate, DateTime endDate);
        Task<IEnumerable<Project>> GetAllUserProjects(string userId);
    }
}
