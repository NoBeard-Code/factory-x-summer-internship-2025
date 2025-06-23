using AMI.EduWork._2025.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Domain.Interfaces.Service {
    public interface ISickLeaveService {

        Task Create(SickLeave entity);
        Task Delete(string id);
        Task<SickLeave> GetById(string id);

        Task Update(SickLeave entity);
        Task<IEnumerable<SickLeave>> GetByUserId(string userId);
        Task<IEnumerable<SickLeave>> GetAllByDate(DateOnly startDate, DateOnly endDate);
        Task<IEnumerable<SickLeave>> GetAllByDateForUser(string userId, DateOnly startDate, DateOnly endDate);

    }
}
