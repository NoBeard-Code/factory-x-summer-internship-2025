using AMI.EduWork._2025.Domain.Entities;
using AMI.EduWork._2025.Domain.Interfaces.Repository;
using AMI.EduWork._2025.Domain.Interfaces.Service;
using AMI.EduWork._2025.Domain.Models.TimeSlice;
using AMI.EduWork._2025.Domain.Models.WorkDay;
using Microsoft.Extensions.Logging;

namespace AMI.EduWork._2025.Domain.Services;

public class TimeSliceService : ITimeSliceService
{
    private readonly ITimeSliceRepository _repository;
    private readonly IUserRepository _userRepository;
    private readonly ILogger<TimeSliceService> _logger;
    public TimeSliceService(ITimeSliceRepository repository,IUserRepository userRepository, ILogger<TimeSliceService> logger)
    {
        _repository = repository;
        _userRepository = userRepository;
        _logger = logger;
    }

    public async Task<bool> Create(TimeSliceModel entity)
    {
        if (entity is null)
        {
            _logger.LogWarning("Attempted to create TimeSlice with null entity");
            return false;
        }
        try
        {
            TimeSlice timeSlice = new TimeSlice
            {
                Id = Guid.NewGuid().ToString(),
                Start = entity.Start,
                End = entity.End,
                TypeOfSlice = entity.TypeOfSlice,
                WorkDayId = entity.WorkDayId,
                ProjectId = entity.ProjectId,
                UserId = entity.UserId,
            };
            await _repository.Create(timeSlice);
            bool result = await _repository.SaveChangesAsync();
            if (result) _logger.LogInformation("Successfully created TimeSlice for user {UserId}.", timeSlice.UserId);
            else _logger.LogWarning("No changes saved when creating TimeSlice for user {UserId}", timeSlice.UserId);

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while creating TimeSlice for user {UserId}.", entity.UserId);
            throw;
        }
    }

    public async Task<bool> DeleteById(string id)
    {
        if (id is null)
        {
            _logger.LogWarning("Attempted to delete TimeSlice with null Id");
            return false;
        }
        try
        {
            await _repository.Delete(id);
            bool result = await _repository.SaveChangesAsync();
            if (result) _logger.LogInformation("Successfully deleted TimeSlice.");
            else _logger.LogWarning("No changes saved when deleting TimeSlice.");
            
            return result;

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while deleting TimeSlice {Id}.", id);
            throw;
        }
    }

    public async Task<IEnumerable<GetTimeSliceModel>> GetAllUserTimeSlices(string userId)
    {
        if (!string.IsNullOrEmpty(userId))
        {
            _logger.LogWarning("Attempted to retrieve all TimeSlices for null user");
            return null;
        }
        if(!await _userRepository.UserExists(userId))
        {
            _logger.LogWarning("Attempted to retrieve all TimeSlices for non exisiting user");
            return null;
        }
        IEnumerable<TimeSlice> entity = await _repository.GetAllUserTimeSlices(userId);
        List<GetTimeSliceModel> timeSlice = entity.Select(ts => new GetTimeSliceModel
        {
            Id = ts.Id,
            Start = ts.Start,
            End = ts.End,
            TypeOfSlice = ts.TypeOfSlice,
            WorkDayId = ts.WorkDayId,
            WorkDay = new GetWorkDayModel
            {
                Id = ts.WorkDayId,
                Date = ts.WorkDay.Date,
            },
            ProjectId = ts.ProjectId,
            UserId = ts.UserId,
        }).ToList();
        return timeSlice;
    }

    public async Task<GetTimeSliceModel> GetById(string id)
    {
        if (!string.IsNullOrEmpty(id))
        {
            _logger.LogWarning("Attempted to retrieve TimeSlice with null Id");
            return null;
        }
        TimeSlice entity = await _repository.GetById(id);
        if (entity is null)
        {
            _logger.LogWarning("TimeSlice with Id {Id} doesn't exist", id);
            return null;
        }
        GetTimeSliceModel timeSlice = new GetTimeSliceModel
        {
            Id = entity.Id,
            Start = entity.Start,
            End = entity.End,
            TypeOfSlice = entity.TypeOfSlice,
            WorkDayId = entity.WorkDayId,
            WorkDay = new GetWorkDayModel
            {
                Id = entity.WorkDayId,
                Date = entity.WorkDay.Date,
            },
            ProjectId = entity.ProjectId,
            UserId = entity.UserId,
        };
        return timeSlice;
    }

    public async Task<bool> Update(GetTimeSliceModel entity)
    {
        if (entity is null)
        {
            _logger.LogWarning("Attempted to update TimeSlice with null entity");
            return false;
        }

        try
        {
            var existing = await _repository.GetById(entity.Id);
            if (existing is null)
            {
                _logger.LogWarning("TimeSlice with Id {Id} not found for update.", entity.Id);
                return false;
            }

            existing.Start = entity.Start;
            existing.End = entity.End;
            existing.TypeOfSlice = entity.TypeOfSlice;
            existing.WorkDayId = entity.WorkDayId;
            existing.ProjectId = entity.ProjectId;
            existing.UserId = entity.UserId;

            _repository.Update(existing);

            bool result = await _repository.SaveChangesAsync();
            if (result)
                _logger.LogInformation("Successfully updated TimeSlice with Id {Id} for user {UserId}.", existing.Id, existing.UserId);
            else
                _logger.LogWarning("No changes saved when updating TimeSlice with Id {Id} for user {UserId}.", existing.Id, existing.UserId);

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while updating TimeSlice with Id {Id} for user {UserId}.", entity.Id, entity.UserId);
            throw;
        }
    }
}
