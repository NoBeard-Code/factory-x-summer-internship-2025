using AMI.EduWork._2025.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Domain.Interfaces.Service {
    public interface IUserOnProjectService {

        Task Create(UserOnProject userOnProject);

        Task Update(UserOnProject userOnProject);

        Task DeleteByUser(string userOnProjectId);

        Task DeleteByProject(string userOnProjectId);

        Task<UserOnProject> GetById(string userOnProjectId);

        Task<IEnumerable<UserOnProject>> GetUsersByProjectId(string projectId);
        Task<IEnumerable<UserOnProject>> GetProjectsByUserId(string userId);
        Task<UserOnProject> GetUserOnProjectAsync(string userId, string projectId);
        Task<IEnumerable<UserOnProject>> GetProjectsForUserForIntervalDateTime(string userId, DateTime startDate, DateTime endDate);
        Task<IEnumerable<UserOnProject>> GetProjectForUsersForIntervalDateTime(string projectId, DateTime startDate, DateTime endDate);
    }
}
