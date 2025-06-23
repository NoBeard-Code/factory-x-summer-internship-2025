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
            var existingProject = _repository.GetProjectByName(project.Name);
            if (existingProject != null) {
                _logger.LogError($"Project with name '{project.Name}' already exists.");
                throw new InvalidOperationException($"Project with name '{project.Name}' already exists.");
            }
            Project project1 = new Project {
                Id = Guid.NewGuid().ToString(),
                Name = project.Name,
                TypeOfProject = project.TypeOfProject,
                Description = project.Description,
                TimeSlices = project.TimeSlices,
                UsersOnProjects = project.UsersOnProjects
            };
            _repository.Create(project1);
            return _repository.SaveChangesAsync();

        }

        public Task Delete(string projectId) {
            var project = _repository.GetById(projectId);
            if (project == null) {
                _logger.LogError($"Project with ID '{projectId}' does not exist.");
                throw new KeyNotFoundException($"Project with ID '{projectId}' does not exist.");
            }
            _repository.Delete(projectId);
            return _repository.SaveChangesAsync();
        }

        public Task<IEnumerable<Project>> GetAllProjectsByUserId(string userId) {
            var projects = _repository.GetAllProjectsByUserId(userId);
            if (projects == null || !projects.Any()) {
                _logger.LogWarning($"No projects found for user ID '{userId}'.");
                throw new KeyNotFoundException($"No projects found for user ID '{userId}'.");
            }
            return projects;
        }

        public Task<Project> GetById(string projectId) {
            var projects = _repository.GetById(projectId);
            if(projects == null) {
                _logger.LogError($"Project with ID '{projectId}' does not exist.");
                throw new KeyNotFoundException($"Project with ID '{projectId}' does not exist.");
            }
            return projects;
        }

        public Task<Project> GetProjectByName(string name) {
            var projects = _repository.GetProjectByName(name);
            if (projects == null) {
                _logger.LogError($"Project with name '{name}' not found.");
                throw new KeyNotFoundException($"Project with name '{name}' not found.");
            }
            return projects;
        }

        public  Task<IEnumerable<Project>> GetProjectsByDateRange(DateTime startDate, DateTime endDate) {
            var projects = _repository.GetProjectsByDateRange(startDate, endDate);
            if (projects == null) {
                _logger.LogWarning($"No projects found in the date range from '{startDate}' to '{endDate}'.");
                throw new KeyNotFoundException($"No projects found in the date range from '{startDate}' to '{endDate}'.");
            }
            return projects;
        }

        public Task<bool> ProjectExists(string name) {
            var exists = _repository.ProjectExists(name);
            return exists;
        }

        public Task Update(Project project) {
            var projectToUpdate = _repository.GetById(project.Id);
            if (projectToUpdate == null) {
                _logger.LogError($"Project with ID '{project.Id}' does not exist.");
                throw new KeyNotFoundException($"Project with ID '{project.Id}' does not exist.");
            }
            Project project1 = new Project {
                Id = project.Id,
                Name = project.Name,
                TypeOfProject = project.TypeOfProject,
                Description = project.Description,
                TimeSlices = project.TimeSlices,
                UsersOnProjects = project.UsersOnProjects
            };
            _repository.Update(project1);
            return _repository.SaveChangesAsync();
        }

       
    }
}
