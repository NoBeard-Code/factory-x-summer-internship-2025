using AMI.EduWork._2025.Domain.Models.WorkDay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Domain.Interfaces.Service
{
    public interface IWorkDayService
    {
        Task<GetWorkDayModel> GetByDate(DateTime date);
        Task<IEnumerable<GetWorkDayModel>> GetAll();
        Task<bool> Create(WorkDayModel entity);
    }
}
