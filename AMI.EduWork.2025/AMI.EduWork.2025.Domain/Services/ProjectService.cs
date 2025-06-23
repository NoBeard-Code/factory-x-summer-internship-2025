using AMI.EduWork._2025.Domain.Entities;
using AMI.EduWork._2025.Domain.Interfaces.Repository;
using AMI.EduWork._2025.Domain.Interfaces.Service;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Domain.Services {
    public class ProjectService : IProjectService {

        private readonly IProjectRepository _repository;
        private readonly ILogger<ContractService> _logger;

        public ProjectService(IProjectRepository repository, ILogger<ContractService> logger) {
            _repository = repository;
            _logger = logger;
        }
        public Task Create(Project project) {
            throw new NotImplementedException();
        }

        public Task Delete(string projectId) {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Project>> GetAllProjectsByUserId(string userId) {
            throw new NotImplementedException();
        }

        public Task<Project> GetById(string projectId) {
            throw new NotImplementedException();
        }

        public Task<Project> GetProjectByName(string name) {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Project>> GetProjectsByDateRange(DateTime startDate, DateTime endDate) {
            throw new NotImplementedException();
        }

        public Task<bool> ProjectExists(string name) {
            throw new NotImplementedException();
        }

        public Task Update(Project project) {
            throw new NotImplementedException();
        }
    }
}
