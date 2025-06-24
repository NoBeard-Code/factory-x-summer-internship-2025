using AMI.EduWork._2025.Domain.Models.UserOnVacationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Domain.Interfaces.Service
{
    public interface IUserOnVacationService
    {
        Task<UserOnVacationGetModel> GetById(string id);
        Task<bool> Create(UserOnVacationCreateModel userOnVacationCreateModel);
        Task<bool> Delete(string id);
        Task<bool> Update(UserOnVacationUpdateModel userOnVacationUpdateModel);
    }
}
