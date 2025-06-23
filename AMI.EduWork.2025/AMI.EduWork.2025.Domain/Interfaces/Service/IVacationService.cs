using AMI.EduWork._2025.Domain.Models.VacationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Domain.Interfaces.Service
{
    public interface IVacationService
    {
        Task<VacationGetModel> GetById(string id);
        Task<bool> Create(VacationCreateModel? vacationCreateModel);
        Task<bool> Update(VacationUpdateModel? vacationUpdateModel);
        Task<bool> Delete(string id);
    }
}
