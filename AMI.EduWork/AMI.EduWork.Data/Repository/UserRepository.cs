using AMI.EduWork.Domain;
using AMI.EduWork.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace AMI.EduWork.Data.Repository;

public class UserRepository : Repository<ApplicationUser>, IUserRepository
{
    public UserRepository(ApplicationDbContext context) : base(context) { }
    public async Task<bool> UserExists(string id)
    {
        return await _dbSet.AnyAsync(u => u.Id == id);
    }

}
