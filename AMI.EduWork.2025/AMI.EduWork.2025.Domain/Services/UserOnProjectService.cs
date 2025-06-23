using AMI.EduWork._2025.Domain.Entities;
using AMI.EduWork._2025.Domain.Interfaces.Service;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Domain.Services {
    public class UserOnProjectService : IUserOnProjectService {

        private readonly IUserOnProjectService _repository;
        private readonly ILogger<UserOnProjectService> _logger;
        public UserOnProjectService(IUserOnProjectService repository, ILogger<UserOnProjectService> logger) {
            _repository = repository;
            _logger = logger;
        }
        public Task Create(UserOnProject userOnProject) {
            throw new NotImplementedException();
        }

        public Task DeleteByProject(string userOnProjectId) {
            throw new NotImplementedException();
        }

        public Task DeleteByUser(string userOnProjectId) {
            throw new NotImplementedException();
        }

        public Task<UserOnProject> GetById(string userOnProjectId) {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserOnProject>> GetProjectForUsersForIntervalDateTime(string projectId, DateTime startDate, DateTime endDate) {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserOnProject>> GetProjectsByUserId(string userId) {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserOnProject>> GetProjectsForUserForIntervalDateTime(string userId, DateTime startDate, DateTime endDate) {
            throw new NotImplementedException();
        }

        public Task<UserOnProject> GetUserOnProjectAsync(string userId, string projectId) {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserOnProject>> GetUsersByProjectId(string projectId) {
            throw new NotImplementedException();
        }

        public Task Update(UserOnProject userOnProject) {
            throw new NotImplementedException();
        }
    }
}
