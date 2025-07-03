using AMI.EduWork.Domain.Models.VacationModel;

namespace AMI.EduWork.Domain.Interfaces.Service
{
    public interface IAnnualVacationService
    {
        Task<AnnualVacationGetModel> GetById(string id);
        Task<IEnumerable<AnnualVacationGetModel>> GetAll();
        Task<bool> Create(AnnualVacationCreateModel? vacationCreateModel);
        Task<bool> Update(AnnualVacationUpdateModel? vacationUpdateModel);
        Task<bool> Delete(string id);
        Task<IEnumerable<AnnualVacationGetModel>> GetByYear(int year);
        Task<IEnumerable<AnnualVacationGetModel>> GetByUser(string userId);
        Task<IEnumerable<AnnualVacationGetModel>> GetByUserYear(int year, string userId);


    }
}
