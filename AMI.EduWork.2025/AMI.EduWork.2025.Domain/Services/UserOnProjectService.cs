using AMI.EduWork._2025.Domain.Entities;
using AMI.EduWork._2025.Domain.Interfaces.Repository;
using AMI.EduWork._2025.Domain.Interfaces.Service;
using AMI.EduWork._2025.Domain.Models.UserOnProject;
using AMI.EduWork._2025.Domain.Models.User;
using AMI.EduWork._2025.Domain.Models.Project;
using Microsoft.Extensions.Logging;

namespace AMI.EduWork._2025.Domain.Services {
    public class UserOnProjectService : IUserOnProjectService {
        private readonly IUserOnProjectRepository _repository;
        private readonly ILogger<UserOnProjectService> _logger;

        public UserOnProjectService(IUserOnProjectRepository repository, ILogger<UserOnProjectService> logger) {
            _repository = repository;
            _logger = logger;
        }

        public async Task Create(UserOnProjectModel model) {
            var exists = await _repository.GetUserOnProject(model.UserId, model.ProjectId);
            if (exists != null) {
                _logger.LogError("User is already assigned to the project.");
                throw new InvalidOperationException("User is already assigned to this project.");
            }

            var entity = new UserOnProject {
                Id = Guid.NewGuid().ToString(),
                UserId = model.UserId,
                ProjectId = model.ProjectId,
                ProjectRole = model.ProjectRole,
                RoleStartDate = model.RoleStartDate,
                RoleEndDate = model.RoleEndDate
            };

            await _repository.Create(entity);
            await _repository.SaveChangesAsync();
        }

        public async Task Update(string id, UserOnProjectModel model) {
            var existing = await _repository.GetById(id);
            if (existing == null) {
                _logger.LogError($"UserOnProject with ID '{id}' not found.");
                throw new KeyNotFoundException($"UserOnProject with ID '{id}' not found.");
            }

            existing.UserId = model.UserId;
            existing.ProjectId = model.ProjectId;
            existing.ProjectRole = model.ProjectRole;
            existing.RoleStartDate = model.RoleStartDate;
            existing.RoleEndDate = model.RoleEndDate;

            await _repository.Update(existing);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteByUser(string userOnProjectId) {
            await _repository.DeleteByUser(userOnProjectId);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteByProject(string userOnProjectId) {
            await _repository.DeleteByProject(userOnProjectId);
            await _repository.SaveChangesAsync();
        }

        public async Task<GetUserOnProjectModel> GetById(string userOnProjectId) {
            var entity = await _repository.GetById(userOnProjectId);
            if (entity == null) {
                _logger.LogError("UserOnProject not found.");
                throw new KeyNotFoundException("UserOnProject not found.");
            }

            return MapToGetModel(entity);
        }

        public async Task<GetUserOnProjectModel> GetUserOnProjectAsync(string userId, string projectId) {
            var entity = await _repository.GetUserOnProject(userId, projectId);
            if (entity == null) {
                _logger.LogError("UserOnProject not found.");
                throw new KeyNotFoundException("UserOnProject not found.");
            }

            return MapToGetModel(entity);
        }

        public async Task<IEnumerable<GetUserOnProjectModel>> GetUsersByProjectId(string projectId) {
            var results = await _repository.GetUsersByProjectId(projectId);
            return results.Select(MapToGetModel);
        }

        public async Task<IEnumerable<GetUserOnProjectModel>> GetProjectsByUserId(string userId) {
            var results = await _repository.GetProjectsByUserId(userId);
            return results.Select(MapToGetModel);
        }

        public async Task<IEnumerable<GetUserOnProjectModel>> GetProjectsForUserForIntervalDateTime(string userId, DateTime startDate, DateTime endDate) {
            var results = await _repository.GetProjectsForUserForIntervalDateTime(userId, startDate, endDate);
            return results.Select(MapToGetModel);
        }

        public async Task<IEnumerable<GetUserOnProjectModel>> GetProjectForUsersForIntervalDateTime(string projectId, DateTime startDate, DateTime endDate) {
            var results = await _repository.GetProjectForUsersForIntervalDateTime(projectId, startDate, endDate);
            return results.Select(MapToGetModel);
        }

        private GetUserOnProjectModel MapToGetModel(UserOnProject entity) {
            return new GetUserOnProjectModel {
                Id = entity.Id,
                UserId = entity.UserId,
                ProjectId = entity.ProjectId,
                ProjectRole = entity.ProjectRole,
                RoleStartDate = entity.RoleStartDate,
                RoleEndDate = entity.RoleEndDate,
                User = new GetUserModel {
                    Id = entity.User?.Id ?? "",
                    UserName = entity.User?.UserName ?? ""
                },
                Project = new GetProjectModel {
                    Id = entity.Project?.Id ?? "",
                    Name = entity.Project?.Name ?? "",
                    TypeOfProject = entity.Project?.TypeOfProject ?? 0,
                    Description = entity.Project?.Description ?? ""
                }
            };
        }
    }
}
