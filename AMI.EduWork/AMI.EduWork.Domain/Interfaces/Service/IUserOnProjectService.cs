using AMI.EduWork.Domain.Entities;
using AMI.EduWork.Domain.Models.UserOnProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork.Domain.Interfaces.Service {
    public interface IUserOnProjectService {
        Task Create(UserOnProjectModel model);
        Task Update(string id, UserOnProjectModel model);

        Task DeleteByUser(string userOnProjectId);
        Task DeleteByProject(string userOnProjectId);

        Task<GetUserOnProjectModel> GetById(string userOnProjectId);

        Task<IEnumerable<GetUserOnProjectModel>> GetUsersByProjectId(string projectId);
        Task<IEnumerable<GetUserOnProjectModel>> GetProjectsByUserId(string userId);
        Task<GetUserOnProjectModel> GetUserOnProjectAsync(string userId, string projectId);

        Task<IEnumerable<GetUserOnProjectModel>> GetProjectsForUserForIntervalDateTime(string userId, DateTime startDate, DateTime endDate);
        Task<IEnumerable<GetUserOnProjectModel>> GetProjectForUsersForIntervalDateTime(string projectId, DateTime startDate, DateTime endDate);
    }

}
