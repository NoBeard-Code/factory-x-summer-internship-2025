using AMI.EduWork._2025.Domain.Entities;
using AMI.EduWork._2025.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Data.Repository
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

    }
}
