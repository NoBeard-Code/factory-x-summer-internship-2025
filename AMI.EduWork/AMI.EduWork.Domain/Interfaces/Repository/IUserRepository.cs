using AMI.EduWork.Domain.IRepository.Repository;

namespace AMI.EduWork.Domain.Interfaces.Repository;

public interface IUserRepository : IRepository<ApplicationUser>
{
    Task<bool> UserExists(string id);
}
