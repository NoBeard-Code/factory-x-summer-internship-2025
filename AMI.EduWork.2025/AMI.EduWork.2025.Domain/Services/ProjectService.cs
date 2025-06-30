using AMI.EduWork._2025.Domain.Entities;
using AMI.EduWork._2025.Domain.Interfaces.Repository;
using AMI.EduWork._2025.Domain.Interfaces.Service;
using AMI.EduWork._2025.Domain.Models;
using AMI.EduWork._2025.Domain.Models.Project;
using AMI.EduWork._2025.Domain.Models.TimeSlice;
using AMI.EduWork._2025.Domain.Models.User;
using AMI.EduWork._2025.Domain.Models.UserOnProject;
using AMI.EduWork._2025.Domain.Models.WorkDay;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace AMI.EduWork._2025.Domain.Services {
    public class ProjectService : IProjectService {
        private readonly IProjectRepository _repository;
        private readonly ILogger<ProjectService> _logger;
        private readonly IMapper _mapper;

        public ProjectService(IProjectRepository repository, ILogger<ProjectService> logger, IMapper mapper) {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task Create(ProjectModel model) {
            if (model == null) {
                _logger.LogError("Project model cannot be null.");
                throw new ArgumentNullException(nameof(model));
            }

            var existing = await _repository.GetProjectByName(model.Name);
            if (existing != null) {
                _logger.LogError($"Project with name '{model.Name}' already exists.");
                throw new InvalidOperationException($"Project with name '{model.Name}' already exists.");
            }

            var project = new Project {
                Id = Guid.NewGuid().ToString(),
                Name = model.Name,
                TypeOfProject = model.TypeOfProject,
                Description = model.Description
            };

            await _repository.Create(project);
            await _repository.SaveChangesAsync();
        }

        public async Task Update(string projectId, ProjectModel model) {
            if (model == null) {
                _logger.LogError("Project model cannot be null.");
                throw new ArgumentNullException(nameof(model));
            }

            var project = await _repository.GetById(projectId);
            if (project == null) {
                _logger.LogError($"Project with ID '{projectId}' does not exist.");
                throw new KeyNotFoundException($"Project with ID '{projectId}' does not exist.");
            }

            project.Name = model.Name;
            project.TypeOfProject = model.TypeOfProject;
            project.Description = model.Description;

            await _repository.Update(project);
            await _repository.SaveChangesAsync();
        }

        public async Task Delete(string projectId) {
            if (string.IsNullOrWhiteSpace(projectId)) {
                _logger.LogError("Project ID cannot be null or empty.");
                throw new ArgumentException("Project ID cannot be null or empty.", nameof(projectId));
            }

            var project = await _repository.GetById(projectId);
            if (project == null) {
                _logger.LogError($"Project with ID '{projectId}' does not exist.");
                throw new KeyNotFoundException($"Project with ID '{projectId}' does not exist.");
            }

            await _repository.Delete(projectId);
            await _repository.SaveChangesAsync();
        }

        public async Task<GetProjectModel> GetById(string projectId) {
            if (string.IsNullOrWhiteSpace(projectId)) {
                _logger.LogError("Project ID cannot be null or empty.");
                throw new ArgumentException("Project ID cannot be null or empty.", nameof(projectId));
            }

            var project = await _repository.GetById(projectId);
            if (project == null) {
                _logger.LogError($"Project with ID '{projectId}' does not exist.");
                throw new KeyNotFoundException($"Project with ID '{projectId}' does not exist.");
            }

            return MapToGetModel(project);
        }

        public async Task<GetProjectModel> GetProjectByName(string name) {
            if (string.IsNullOrWhiteSpace(name)) {
                _logger.LogError("Project name cannot be null or empty.");
                throw new ArgumentException("Project name cannot be null or empty.", nameof(name));
            }

            var project = await _repository.GetProjectByName(name);
            if (project == null) {
                _logger.LogError($"Project with name '{name}' not found.");
                return MapToNullModel(); 
            }

            return MapToGetModel(project);
        }


        public async Task<IEnumerable<GetProjectModel>> GetProjectsByDateRange(DateTime startDate, DateTime endDate) {
            if (startDate == default || endDate == default) {
                _logger.LogError("Invalid date range.");
                throw new ArgumentException("Start or end date cannot be default.");
            }

            if (startDate > endDate) {
                _logger.LogError("Start date is after end date.");
                throw new ArgumentException("Start date must be before or equal to end date.");
            }

            var projects = await _repository.GetProjectsByDateRange(startDate, endDate);
            if (projects == null || !projects.Any()) {
                _logger.LogWarning($"No projects found between {startDate} and {endDate}.");
                throw new KeyNotFoundException("No projects found in the specified date range.");
            }

            return projects.Select(MapToGetModel);
        }

        public async Task<bool> ProjectExists(string name) {
            if (string.IsNullOrWhiteSpace(name)) {
                _logger.LogError("Project name cannot be null or empty.");
                throw new ArgumentException("Project name cannot be null or empty.", nameof(name));
            }

            return await _repository.ProjectExists(name);
        }

        private GetProjectModel MapToNullModel() {
            return new GetProjectModel {
                Description = string.Empty,
                Id = string.Empty,
                Name = string.Empty,
                TimeSlices = new List<GetTimeSliceModel>(),
                TypeOfProject = 0,
                UsersOnProjects = new List<GetUserOnProjectModel>()

            };
        }


        private GetProjectModel MapToGetModel(Project project) {
            return new GetProjectModel {
                Id = project.Id,
                Name = project.Name,
                TypeOfProject = project.TypeOfProject,
                Description = project.Description,

                TimeSlices = project.TimeSlices?.Select(ts => new GetTimeSliceModel {
                    Id = ts.Id,
                    Start = ts.Start,
                    End = ts.End,
                    TypeOfSlice = ts.TypeOfSlice,
                    ProjectId = ts.ProjectId,
                    Project = ts.Project != null ? new GetProjectModelNoRefrences 
                    {
                        Id = ts.ProjectId,
                        Description = ts.Project.Description,
                        Name = ts.Project.Name,
                        TypeOfProject = ts.Project.TypeOfProject,
                    } : null,
                    WorkDayId = ts.WorkDayId,
                    UserId = ts.UserId ?? string.Empty,

                    WorkDay = ts.WorkDay != null ? new GetWorkDayModel {
                        Id = ts.WorkDay.Id,
                        Date = ts.WorkDay.Date
                    } : new GetWorkDayModel { Id = "", Date = DateTime.MinValue },

                    User = ts.User != null ? new GetUserModel {
                        Id = ts.User.Id,
                        UserName = ts.User.UserName
                    } : new GetUserModel { Id = "", UserName = "Unknown" }

                }).ToList(),

                UsersOnProjects = project.UsersOnProjects?.Select(uop => new GetUserOnProjectModel {
                    Id = uop.Id,
                    UserId = uop.UserId,
                    ProjectId = uop.ProjectId,
                    ProjectRole = uop.ProjectRole,
                    RoleStartDate = uop.RoleStartDate,
                    RoleEndDate = uop.RoleEndDate,

                    User = new GetUserModel {
                        Id = uop.User?.Id ?? "",
                        UserName = uop.User?.UserName ?? "Unknown"
                    },

                    Project = new GetProjectModel {
                        Id = uop.Project?.Id ?? "",
                        Name = uop.Project?.Name ?? "",
                        Description = uop.Project?.Description ?? "",
                        TypeOfProject = uop.Project?.TypeOfProject ?? 0
                    }
                }).ToList()
            };
        }

        public async Task<IEnumerable<GetProjectModel>> GetAllUserProjects(string userId)
        {
            if (userId is null)
            {
                _logger.LogError("Invalid user.");
                throw new ArgumentException("User Id cannot be null.");
            }

            var projects = await _repository.GetAllUserProjects(userId);
            if (projects == null || !projects.Any())
            {
                _logger.LogWarning($"No projects found for user.");
                throw new KeyNotFoundException("No projects found for user.");
            }
            List<GetProjectModel> getProjectModel = _mapper.Map<List<GetProjectModel>>(projects);

            return getProjectModel;
        }
    }
}
