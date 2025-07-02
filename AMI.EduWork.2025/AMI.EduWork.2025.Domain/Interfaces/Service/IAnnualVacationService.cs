using AMI.EduWork._2025.Domain.Models.VacationModel;

namespace AMI.EduWork._2025.Domain.Interfaces.Service
{
    public interface IAnnualVacationService
    {
        Task<AnnualVacationGetModel> GetById(string id);
        Task<IEnumerable<AnnualVacationGetModel>> GetAll();
        Task<bool> Create(AnnualVacationCreateModel? vacationCreateModel);
        Task<bool> Update(AnnualVacationUpdateModel? vacationUpdateModel);
        Task<bool> Delete(string id);
    }
}
