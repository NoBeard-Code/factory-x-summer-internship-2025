using AMI.EduWork.Domain.Entities;
using AMI.EduWork.Domain.IRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork.Domain.Interfaces.Repository {
    public interface ISickLeaveRepository : IRepository<SickLeave>{
        Task<IEnumerable<SickLeave>> GetByUserId(string userId);

        Task<IEnumerable<SickLeave>> GetAllByDate(DateOnly startDate, DateOnly endDate);

        Task<IEnumerable<SickLeave>> GetAllByDateForUser(string userId, DateOnly startDate, DateOnly endDate);

    }
}
