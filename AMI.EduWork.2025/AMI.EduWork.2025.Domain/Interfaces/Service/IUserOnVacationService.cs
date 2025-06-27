using AMI.EduWork._2025.Domain.Models.UserOnVacationModel;

namespace AMI.EduWork._2025.Domain.Interfaces.Service
{
    public interface IUserOnVacationService
    {
        Task<UserOnVacationGetModel> GetById(string id);
        Task<IEnumerable<UserOnVacationGetModel>> GetByUserIdYear(string UserId, int year);
        Task<IEnumerable<UserOnVacationGetModel>> GetByUser(string UserId);
        Task<IEnumerable<UserOnVacationGetModel>> GetAll();
        Task<bool> Create(UserOnVacationCreateModel userOnVacationCreateModel);
        Task<bool> Delete(string id);
        Task<bool> Update(UserOnVacationUpdateModel userOnVacationUpdateModel);
    }
}
