using AMI.EduWork._2025.Domain.Entities;
using AMI.EduWork._2025.Domain.IRepository.Repository;

namespace AMI.EduWork._2025.Domain.Interfaces.Repository
{
    public interface IAnnualVacationRepository: IRepository<AnnualVacation>
    {
        Task<IEnumerable<AnnualVacation>> GetByUser(string userId);
        Task<IEnumerable<AnnualVacation>> GetByYear(int year);
        Task<IEnumerable<AnnualVacation>> GetByUserYear(int year, string userId);

    }
}
