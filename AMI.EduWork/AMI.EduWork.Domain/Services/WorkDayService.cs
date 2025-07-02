using AMI.EduWork.Domain.Entities;
using AMI.EduWork.Domain.Helpers;
using AMI.EduWork.Domain.Interfaces.Repository;
using AMI.EduWork.Domain.Interfaces.Service;
using AMI.EduWork.Domain.Models.WorkDay;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace AMI.EduWork.Domain.Services;

public class WorkDayService : IWorkDayService
{
    private readonly IWorkDayRepository _repository;
    private readonly ILogger<WorkDayService> _logger;
    private readonly IMapper _mapper;
    public WorkDayService(IWorkDayRepository repository, ILogger<WorkDayService> logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
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
            WorkDay workday = _mapper.Map<WorkDay>(entity);

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
        List<GetWorkDayModel> workday = _mapper.Map<List<GetWorkDayModel>>(entity);
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
        GetWorkDayModel workday = _mapper.Map<GetWorkDayModel>(entity);

        return workday;
    }
}
