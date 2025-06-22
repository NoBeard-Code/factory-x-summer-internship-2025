using AMI.EduWork._2025.Domain.Entities;
using AMI.EduWork._2025.Domain.IRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Domain.Interfaces.Repository;

public interface IWorkDayRepository : IRepository<WorkDay>
{
    Task<WorkDay> GetByDate(DateTime date);
    Task<bool> DayExists(DateTime date);
}
