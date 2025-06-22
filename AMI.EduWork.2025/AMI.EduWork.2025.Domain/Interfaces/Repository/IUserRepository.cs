using AMI.EduWork._2025.Domain.IRepository.Repository;

namespace AMI.EduWork._2025.Domain.Interfaces.Repository;

public interface IUserRepository : IRepository<ApplicationUser>
{
    Task<bool> UserExists(string id);
}
