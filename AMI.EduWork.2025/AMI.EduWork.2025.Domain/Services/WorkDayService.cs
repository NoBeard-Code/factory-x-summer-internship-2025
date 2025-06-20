using AMI.EduWork._2025.Domain.Interfaces.Repository;
using AMI.EduWork._2025.Domain.Interfaces.Service;
using AMI.EduWork._2025.Domain.Models.WorkDay;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Domain.Services;

public class WorkDayService : IWorkDayService
{
    private readonly IWorkDayRepository _repository;
    private readonly ILogger _logger;
    public WorkDayService(IWorkDayRepository repository, ILogger logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public Task Create(WorkDayModel entity)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<GetWorkDayModel>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<GetWorkDayModel> GetByDate(DateTime date)
    {
        throw new NotImplementedException();
    }
}
