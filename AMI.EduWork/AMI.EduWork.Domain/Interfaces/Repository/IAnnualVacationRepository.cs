using AMI.EduWork.Domain.Entities;
using AMI.EduWork.Domain.IRepository.Repository;

namespace AMI.EduWork.Domain.Interfaces.Repository
{
    public interface IAnnualVacationRepository: IRepository<AnnualVacation>
    {
        Task<IEnumerable<AnnualVacation>> GetByUser(string userId);
        Task<IEnumerable<AnnualVacation>> GetByYear(int year);
        Task<IEnumerable<AnnualVacation>> GetByUserYear(int year, string userId);
    }
}
