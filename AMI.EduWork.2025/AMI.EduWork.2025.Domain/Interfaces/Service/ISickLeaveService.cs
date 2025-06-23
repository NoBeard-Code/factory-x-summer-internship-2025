using AMI.EduWork._2025.Domain.Entities;
using AMI.EduWork._2025.Domain.Models.SickLeave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Domain.Interfaces.Service {
    public interface ISickLeaveService {
        Task Create(SickLeaveModel model);
        Task Update(string id, SickLeaveModel model);
        Task Delete(string id);

        Task<GetSickLeaveModel> GetById(string id);
        Task<IEnumerable<GetSickLeaveModel>> GetByUserId(string userId);
        Task<IEnumerable<GetSickLeaveModel>> GetAllByDate(DateOnly startDate, DateOnly endDate);
        Task<IEnumerable<GetSickLeaveModel>> GetAllByDateForUser(string userId, DateOnly startDate, DateOnly endDate);
    }

}
