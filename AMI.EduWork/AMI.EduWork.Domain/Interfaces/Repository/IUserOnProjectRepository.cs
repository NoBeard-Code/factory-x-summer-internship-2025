using AMI.EduWork.Domain.Entities;
using AMI.EduWork.Domain.IRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork.Domain.Interfaces.Repository {
    public interface IUserOnProjectRepository : IRepository<UserOnProject>{
        public Task<IEnumerable<UserOnProject>> GetUsersByProjectId(string projectId);
        public Task<IEnumerable<UserOnProject>> GetProjectsByUserId(string userId);

        public Task<IEnumerable<UserOnProject>> GetProjectsByApplicationUser(ApplicationUser user);

        public Task<UserOnProject> GetUserOnProject(string userId, string projectId);

        public Task<IEnumerable<UserOnProject>> GetProjectsForUserForIntervalDateTime(string userId, DateTime startDate, DateTime endDate);
        public Task<IEnumerable<UserOnProject>> GetProjectForUsersForIntervalDateTime(string projectId, DateTime startDate, DateTime endDate);

        public Task DeleteByUser(string userId);
        public Task DeleteByProject(string projectId);

    }
}
