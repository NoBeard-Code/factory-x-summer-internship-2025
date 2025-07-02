using AMI.EduWork.Domain.Entities;
using AMI.EduWork.Domain.IRepository.Repository;

namespace AMI.EduWork.Domain.Interfaces.Repository;

public interface IWorkDayRepository : IRepository<WorkDay>
{
    Task<WorkDay> GetByDate(DateTime date);
    Task<bool> DayExists(DateTime date);
}
