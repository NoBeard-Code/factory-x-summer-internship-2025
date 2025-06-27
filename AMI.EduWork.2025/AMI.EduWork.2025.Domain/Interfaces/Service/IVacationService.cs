using AMI.EduWork._2025.Domain.Models.VacationModel;

namespace AMI.EduWork._2025.Domain.Interfaces.Service
{
    public interface IVacationService
    {
        Task<VacationGetModel> GetById(string id);
        Task<IEnumerable<VacationGetModel>> GetAll();
        Task<bool> Create(VacationCreateModel? vacationCreateModel);
        Task<bool> Update(VacationUpdateModel? vacationUpdateModel);
        Task<bool> Delete(string id);
    }
}
