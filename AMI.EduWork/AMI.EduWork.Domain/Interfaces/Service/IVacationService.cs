using AMI.EduWork.Domain.Models.UserOnVacationModel;

namespace AMI.EduWork.Domain.Interfaces.Service
{
    public interface IVacationService
    {
        Task<VacationGetModel> GetById(string id);
        Task<IEnumerable<VacationGetModel>> GetAll();
        Task<bool> Create(VacationCreateModel userOnVacationCreateModel);
        Task<bool> Delete(string id);
        Task<bool> Update(VacationUpdateModel userOnVacationUpdateModel);
    }
}
