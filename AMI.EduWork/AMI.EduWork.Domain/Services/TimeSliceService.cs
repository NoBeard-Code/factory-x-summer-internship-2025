using AMI.EduWork.Domain.Entities;
using AMI.EduWork.Domain.Helpers;
using AMI.EduWork.Domain.Interfaces.Repository;
using AMI.EduWork.Domain.Interfaces.Service;
using AMI.EduWork.Domain.Models.Project;
using AMI.EduWork.Domain.Models.TimeSlice;
using AMI.EduWork.Domain.Models.User;
using AMI.EduWork.Domain.Models.WorkDay;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace AMI.EduWork.Domain.Services;

public class TimeSliceService : ITimeSliceService
{
    private readonly ITimeSliceRepository _repository;
    private readonly IUserRepository _userRepository;
    private readonly IWorkDayRepository _workDayRepository;
    private readonly IWorkDayService _workDayService;
    private readonly ILogger<TimeSliceService> _logger;
    private readonly IMapper _mapper;

    public TimeSliceService(ITimeSliceRepository repository,IUserRepository userRepository, ILogger<TimeSliceService> logger, IWorkDayRepository workDayRepository, IWorkDayService workDayService, IMapper mapper)
    {
        _repository = repository;
        _userRepository = userRepository;
        _logger = logger;
        _workDayRepository = workDayRepository;
        _workDayService = workDayService;
        _mapper = mapper;
    }

    public async Task<TimeSpan?> CalculateUserWorkTime(IEnumerable<GetTimeSliceModel> timeSlices)
    {
        if (timeSlices == null)
        {
            _logger.LogWarning("Attempted to calculate work time for zero TimeSlices");
            return null;
        }

        TimeSpan? total = TimeSpan.Zero;

        foreach (var slice in timeSlices)
        {
            if (slice.TypeOfSlice == 1 || slice.TypeOfSlice == 3)
            {
                if (slice.Start != null && slice.End != null)
                {
                    total += slice.End - slice.Start;
                }
            }
        }

        return await Task.FromResult(total);
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
            GetWorkDayModel workDay = await _workDayService.GetByDate(entity.Start.Value);

            TimeSlice timeSlice = _mapper.Map<TimeSlice>(entity);
            timeSlice.WorkDayId = workDay.Id;

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
        var timeSlice = _mapper.Map<List<GetTimeSliceModel>>(entity);
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
        DateTime onlyDate = DateExtension.GetDateOnly(date);
        IEnumerable<TimeSlice> entity = await _repository.GetAllUserTimeSlicesByDate(userId, onlyDate);
        if(entity is null)
        {
            _logger.LogWarning("TimeSlices for date {date} doesn't exist", onlyDate.Date);
            return null;
        }
        List<GetTimeSliceModel> timeSlice = _mapper.Map<List<GetTimeSliceModel>>(entity);
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
        GetTimeSliceModel timeSlice = _mapper.Map<GetTimeSliceModel>(entity);
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
            {
                var existingDate = existing.Start.Date;
                var newDate = entity.Start.Value.Date;
                if (existingDate != newDate)
                {
                    var workDay = await _workDayService.GetByDate(newDate);
                    if (workDay != null)
                    {
                        existing.WorkDayId = workDay.Id;
                    }
                }
                existing.Start = entity.Start.Value;
            }

            if (entity.End != null)
                existing.End = entity.End.Value;

            if (entity.TypeOfSlice != existing.TypeOfSlice)
                existing.TypeOfSlice = entity.TypeOfSlice;

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
