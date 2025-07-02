using AMI.EduWork.Domain.Entities;
using AMI.EduWork.Domain.IRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork.Domain.Interfaces.Repository {
    public interface IProjectRepository : IRepository<Project> {
        Task<Project?> GetProjectByName(string name);
        Task<bool> ProjectExists(string name);
        Task<IEnumerable<Project>> GetProjectsByDateRange(DateTime startDate, DateTime endDate);
        Task<IEnumerable<Project>> GetAllUserProjects(string userId);
    }
}
