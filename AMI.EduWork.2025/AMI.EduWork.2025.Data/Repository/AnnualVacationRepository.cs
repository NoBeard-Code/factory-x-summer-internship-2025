using AMI.EduWork._2025.Domain.Entities;
using AMI.EduWork._2025.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace AMI.EduWork._2025.Data.Repository
{
    public class AnnualVacationRepository : Repository<AnnualVacation>, IAnnualVacationRepository
    {
        public AnnualVacationRepository(ApplicationDbContext contex) :base(contex) { }
        public override async Task<IEnumerable<AnnualVacation>> GetAll()
        {
            return await base._context.AnnualVacations.Include(x=> x.Vacations).Include(x => x.User).ToListAsync();
        }
        public override async Task<AnnualVacation> GetById(string id)
        {
            return await base._context.AnnualVacations.Include(x => x.Vacations).Include(x => x.User).Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
