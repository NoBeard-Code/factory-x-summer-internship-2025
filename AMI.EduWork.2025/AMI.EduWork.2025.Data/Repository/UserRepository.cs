using AMI.EduWork._2025.Domain;
using AMI.EduWork._2025.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace AMI.EduWork._2025.Data.Repository;

public class UserRepository : Repository<ApplicationUser>, IUserRepository
{
    public UserRepository(ApplicationDbContext context) : base(context) { }
    public async Task<bool> UserExists(string id)
    {
        return await _dbSet.AnyAsync(u => u.Id == id);
    }

}
