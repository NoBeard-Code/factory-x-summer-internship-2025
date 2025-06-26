using AMI.EduWork._2025.Domain.Entities;
using AMI.EduWork._2025.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace AMI.EduWork._2025.Data.Repository
{
    public class VacationRepository : Repository<AnnualVacation>, IVacationRepository
    {
        public VacationRepository(ApplicationDbContext contex) :base(contex) { }
        public override async Task<IEnumerable<AnnualVacation>> GetAll()
        {
            return await base._context.AnnualVacations.Include(x=> x.UsersOnVacations).ToListAsync();
        }
        public override async Task<AnnualVacation> GetById(string id)
        {
            return await base._context.AnnualVacations.Include(x => x.UsersOnVacations).Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
