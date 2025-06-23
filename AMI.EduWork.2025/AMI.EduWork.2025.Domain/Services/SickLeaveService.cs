using AMI.EduWork._2025.Domain.Entities;
using AMI.EduWork._2025.Domain.Interfaces.Repository;
using AMI.EduWork._2025.Domain.Interfaces.Service;
using AMI.EduWork._2025.Domain.Models.SickLeave;
using AMI.EduWork._2025.Domain.Models.User;
using Microsoft.Extensions.Logging;

namespace AMI.EduWork._2025.Domain.Services {
    public class SickLeaveService : ISickLeaveService {
        private readonly ISickLeaveRepository _repository;
        private readonly ILogger<SickLeaveService> _logger;

        public SickLeaveService(ISickLeaveRepository repository, ILogger<SickLeaveService> logger) {
            _repository = repository;
            _logger = logger;
        }

        public async Task Create(SickLeaveModel model) {
            if (model == null) {
                _logger.LogError("SickLeaveModel cannot be null.");
                throw new ArgumentNullException(nameof(model));
            }

            var sickLeave = new SickLeave {
                Id = Guid.NewGuid().ToString(),
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Year = model.Year,
                UserId = model.UserId
            };

            await _repository.Create(sickLeave);
            await _repository.SaveChangesAsync();
        }

        public async Task Update(string id, SickLeaveModel model) {
            var existing = await _repository.GetById(id);
            if (existing == null) {
                _logger.LogError($"Sick leave with ID '{id}' does not exist.");
                throw new KeyNotFoundException($"Sick leave with ID '{id}' does not exist.");
            }

            existing.StartDate = model.StartDate;
            existing.EndDate = model.EndDate;
            existing.Year = model.Year;
            existing.UserId = model.UserId;

            await _repository.Update(existing);
            await _repository.SaveChangesAsync();
        }

        public async Task Delete(string id) {
            if (string.IsNullOrEmpty(id)) {
                _logger.LogError("Sick leave ID cannot be null or empty.");
                throw new ArgumentException("Sick leave ID cannot be null or empty.", nameof(id));
            }

            var existing = await _repository.GetById(id);
            if (existing == null) {
                _logger.LogError($"Sick leave with ID '{id}' does not exist.");
                throw new KeyNotFoundException($"Sick leave with ID '{id}' does not exist.");
            }

            await _repository.Delete(id);
            await _repository.SaveChangesAsync();
        }

        public async Task<GetSickLeaveModel> GetById(string id) {
            var entity = await _repository.GetById(id);
            if (entity == null) {
                _logger.LogError($"Sick leave with ID '{id}' does not exist.");
                throw new KeyNotFoundException($"Sick leave with ID '{id}' does not exist.");
            }

            return MapToGetModel(entity);
        }

        public async Task<IEnumerable<GetSickLeaveModel>> GetByUserId(string userId) {
            var results = await _repository.GetByUserId(userId);
            if (results == null || !results.Any()) {
                _logger.LogWarning($"No sick leaves found for user ID '{userId}'.");
                throw new KeyNotFoundException($"No sick leaves found for user ID '{userId}'.");
            }

            return results.Select(MapToGetModel);
        }

        public async Task<IEnumerable<GetSickLeaveModel>> GetAllByDate(DateOnly startDate, DateOnly endDate) {
            if (startDate == default || endDate == default) {
                _logger.LogError("Start or end date is default.");
                throw new ArgumentException("Start and end date must be valid.");
            }

            if (startDate > endDate) {
                _logger.LogError("Start date cannot be after end date.");
                throw new ArgumentException("Start date must be before or equal to end date.");
            }

            var results = await _repository.GetAllByDate(startDate, endDate);
            if (results == null || !results.Any()) {
                _logger.LogWarning($"No sick leaves found from {startDate} to {endDate}.");
                throw new KeyNotFoundException("No sick leaves found in the specified date range.");
            }

            return results.Select(MapToGetModel);
        }

        public async Task<IEnumerable<GetSickLeaveModel>> GetAllByDateForUser(string userId, DateOnly startDate, DateOnly endDate) {
            if (string.IsNullOrEmpty(userId)) {
                _logger.LogError("User ID cannot be null or empty.");
                throw new ArgumentException("User ID cannot be null or empty.", nameof(userId));
            }

            var results = await _repository.GetAllByDateForUser(userId, startDate, endDate);
            if (results == null || !results.Any()) {
                _logger.LogWarning($"No sick leaves found for user '{userId}' in the date range.");
                throw new KeyNotFoundException("No sick leaves found for this user in the specified range.");
            }

            return results.Select(MapToGetModel);
        }

        private GetSickLeaveModel MapToGetModel(SickLeave entity) {
            return new GetSickLeaveModel {
                Id = entity.Id,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                Year = entity.Year,
                UserId = entity.UserId,
                User = entity.User != null
                    ? new GetUserModel {
                        Id = entity.User.Id,
                        UserName = entity.User.UserName
                    }
                    : throw new InvalidOperationException("User reference was null in SickLeave entity.")
            };
        }
    }
}
