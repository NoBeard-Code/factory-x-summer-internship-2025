using AMI.EduWork._2025.Domain.Entities;
using AMI.EduWork._2025.Domain.Interfaces.Repository;
using AMI.EduWork._2025.Domain.Interfaces.Service;
using AMI.EduWork._2025.Domain.Models.TimeSlice;
using AMI.EduWork._2025.Domain.Models.User;
using AMI.EduWork._2025.Domain.Models.WorkDay;
using Microsoft.Extensions.Logging;

namespace AMI.EduWork._2025.Domain.Services;

public class TimeSliceService : ITimeSliceService
{
    private readonly ITimeSliceRepository _repository;
    private readonly IUserRepository _userRepository;
    private readonly IWorkDayRepository _workDayRepository;
    private readonly ILogger<TimeSliceService> _logger;
    public TimeSliceService(ITimeSliceRepository repository,IUserRepository userRepository, ILogger<TimeSliceService> logger, IWorkDayRepository workDayRepository)
    {
        _repository = repository;
        _userRepository = userRepository;
        _logger = logger;
        _workDayRepository = workDayRepository;
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
            if (!entity.Start.HasValue)
            {
                _logger.LogWarning("Attempted to create TimeSlice without Start date/time");
                return false;
            }
            DateTime startTime = new DateTime(entity.Start.Value.Year, entity.Start.Value.Month, entity.Start.Value.Day, 0, 0, 0);
            WorkDay workDay = await _workDayRepository.GetByDate(startTime);
            TimeSlice timeSlice = new TimeSlice
            {
                Id = Guid.NewGuid().ToString(),
                Start = entity.Start.Value,
                End = entity.End.Value,
                TypeOfSlice = entity.TypeOfSlice,
                WorkDayId = workDay.Id,
                ProjectId = entity.ProjectId,
                UserId = entity.UserId,
                Description = entity.Description,
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
        if (string.IsNullOrEmpty(userId))
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
            Description = ts.Description,
            WorkDayId = ts.WorkDayId,
            WorkDay = new GetWorkDayModel
            {
                Id = ts.WorkDayId,
                Date = ts.WorkDay.Date,
            },
            ProjectId = ts.ProjectId,
            UserId = ts.UserId,
            User = new GetUserModel
            {
                Id = ts.Id,
                UserName = ts.User.UserName,
                NormalizedUserName = ts.User.NormalizedUserName,
                Email = ts.User.Email,
                NormalizedEmail = ts.User.NormalizedEmail,
                EmailConfirmed = ts.User.EmailConfirmed,
                PhoneNumber = ts.User.PhoneNumber,
                PhoneNumberConfirmed = ts.User.PhoneNumberConfirmed,
                TwoFactorEnabled = ts.User.TwoFactorEnabled,
                LockoutEnd = ts.User.LockoutEnd,
                LockoutEnabled = ts.User.LockoutEnabled,
                AccessFailedCount = ts.User.AccessFailedCount,
                Role = ts.User.Role
            }
        }).ToList();
        return timeSlice;
    }

    public async Task<IEnumerable<GetTimeSliceModel>> GetAllUserTimeSlicesByDate(string userId, DateTime date)
    {
        if (string.IsNullOrEmpty(userId))
        {
            _logger.LogWarning("Attempted to retrieve all TimeSlices for null user");
            return null;
        }
        if (!await _userRepository.UserExists(userId))
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
            Description = ts.Description,
            WorkDayId = ts.WorkDayId,
            WorkDay = new GetWorkDayModel
            {
                Id = ts.WorkDayId,
                Date = ts.WorkDay.Date,
            },
            ProjectId = ts.ProjectId,
            UserId = ts.UserId,
            User = new GetUserModel
            {
                Id = ts.Id,
                UserName = ts.User.UserName,
                NormalizedUserName = ts.User.NormalizedUserName,
                Email = ts.User.Email,
                NormalizedEmail = ts.User.NormalizedEmail,
                EmailConfirmed = ts.User.EmailConfirmed,
                PhoneNumber = ts.User.PhoneNumber,
                PhoneNumberConfirmed = ts.User.PhoneNumberConfirmed,
                TwoFactorEnabled = ts.User.TwoFactorEnabled,
                LockoutEnd = ts.User.LockoutEnd,
                LockoutEnabled = ts.User.LockoutEnabled,
                AccessFailedCount = ts.User.AccessFailedCount,
                Role = ts.User.Role
            }
        }).ToList();
        return timeSlice;
    }

    public async Task<GetTimeSliceModel> GetById(string id)
    {
        if (string.IsNullOrEmpty(id))
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
            Description = entity.Description,
            WorkDayId = entity.WorkDayId,
            WorkDay = new GetWorkDayModel
            {
                Id = entity.WorkDayId,
                Date = entity.WorkDay.Date,
            },
            ProjectId = entity.ProjectId,
            UserId = entity.UserId,
            User = new GetUserModel
            {
                Id = entity.Id,
                UserName = entity.User.UserName,
                NormalizedUserName = entity.User.NormalizedUserName,
                Email = entity.User.Email,
                NormalizedEmail = entity.User.NormalizedEmail,
                EmailConfirmed = entity.User.EmailConfirmed,
                PhoneNumber = entity.User.PhoneNumber,
                PhoneNumberConfirmed = entity.User.PhoneNumberConfirmed,
                TwoFactorEnabled = entity.User.TwoFactorEnabled,
                LockoutEnd = entity.User.LockoutEnd,
                LockoutEnabled = entity.User.LockoutEnabled,
                AccessFailedCount = entity.User.AccessFailedCount,
                Role = entity.User.Role
            }
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

            if (entity.Start != null)
                existing.Start = entity.Start.Value;

            if (entity.End != null)
                existing.End = entity.End.Value;

            if (entity.TypeOfSlice != existing.TypeOfSlice)
                existing.TypeOfSlice = entity.TypeOfSlice;

            if (entity.WorkDayId != null)
                existing.WorkDayId = entity.WorkDayId;

            if (entity.ProjectId != null)
                existing.ProjectId = entity.ProjectId;

            if (entity.Description != null)
                existing.Description = entity.Description;

            await _repository.Update(existing);

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
