using AMI.EduWork._2025.Domain.Entities;
using AMI.EduWork._2025.Domain.Helpers;
using AMI.EduWork._2025.Domain.Interfaces.Repository;
using AMI.EduWork._2025.Domain.Interfaces.Service;
using AMI.EduWork._2025.Domain.Models.WorkDay;
using Microsoft.Extensions.Logging;

namespace AMI.EduWork._2025.Domain.Services;

public class WorkDayService : IWorkDayService
{
    private readonly IWorkDayRepository _repository;
    private readonly ILogger<WorkDayService> _logger;
    public WorkDayService(IWorkDayRepository repository, ILogger<WorkDayService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<bool> Create(WorkDayModel entity)
    {
        entity.Date = DateExtension.GetDateOnly(entity.Date);

        if (entity is null)
        {
            _logger.LogWarning("Attempted to create WorkDay with null entity");
            return false;
        }
        if (await _repository.DayExists(entity.Date))
        {
            _logger.LogInformation("WorkDay for date {Date} exists.", entity.Date);
            return true;
        }
        try
        {
            WorkDay workday = new WorkDay
            {
                Id = Guid.NewGuid().ToString(),
                Date = entity.Date.Date,
            };
            await _repository.Create(workday);
            bool result = await _repository.SaveChangesAsync();
            if(result) _logger.LogInformation("Successfully created WorkDay for date {Date}.", workday.Date);
            else _logger.LogWarning("No changes saved when creating WorkDay with date {Date}", workday.Date);

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while creating WorkDay for date {Date}.", entity.Date);
            throw;
        }
       
    }

    public async Task<IEnumerable<GetWorkDayModel>> GetAll()
    {
        IEnumerable<WorkDay> entity = await _repository.GetAll();
        List<GetWorkDayModel> workday = entity.Select(x => new GetWorkDayModel
        {
            Id = x.Id,
            Date = x.Date,
        }).ToList();
        return workday;
    }

    public async Task<GetWorkDayModel> GetByDate(DateTime date)
    {
        DateTime onlyDate = DateExtension.GetDateOnly(date);
        WorkDay entity = await _repository.GetByDate(onlyDate);
        if (entity is null)
        {
            _logger.LogWarning("Attempted to fetch WorkDay without date");
            await Create(new WorkDayModel
            {
                Date = onlyDate
            });
            entity = await _repository.GetByDate(onlyDate);

        }
        GetWorkDayModel workday = new GetWorkDayModel
        {
            Id = entity.Id,
            Date = entity.Date,
        };
        return workday;
    }
}
