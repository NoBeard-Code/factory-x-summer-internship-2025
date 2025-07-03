using AMI.EduWork.Domain.Entities;
using AMI.EduWork.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace AMI.EduWork.Data.Repository
{
    public class ContractRepository : Repository<Contract>, IContractRepository
    {
        public ContractRepository(ApplicationDbContext context) :base(context) { }
        public override async Task<IEnumerable<Contract>> GetAll()
        {
            return await base._context.Contracts.Include(x => x.User).ToListAsync();
        }
        public override async Task<Contract> GetById(string id)
        {
            return await base._context.Contracts.Include(x => x.User).Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Contract>> GetByUserIsActive(string userId)
        {
            return await _dbSet.Include(x => x.User).Where(x => x.User.Id == userId && x.IsActive).ToListAsync();

        }
    }
}
