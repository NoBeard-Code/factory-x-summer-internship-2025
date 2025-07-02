using AMI.EduWork._2025.Domain.Models.UserOnVacationModel;

namespace AMI.EduWork._2025.Domain.Interfaces.Service
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
