using AMI.EduWork.Domain.Models.WorkDay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork.Domain.Interfaces.Service
{
    public interface IWorkDayService
    {
        Task<GetWorkDayModel> GetByDate(DateTime date);
        Task<IEnumerable<GetWorkDayModel>> GetAll();
        Task<bool> Create(WorkDayModel entity);
    }
}
