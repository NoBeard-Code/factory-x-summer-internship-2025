using AMI.EduWork.Domain.Entities;
using AMI.EduWork.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace AMI.EduWork.Data.Repository
{
    public class AnnualVacationRepository : Repository<AnnualVacation>, IAnnualVacationRepository
    {
        public AnnualVacationRepository(ApplicationDbContext contex) : base(contex) { }
        public override async Task<IEnumerable<AnnualVacation>> GetAll()
        {
            return await base._context.AnnualVacations.
                Include(x => x.Vacations).
                Include(x => x.User).
                ToListAsync();
        }
        public override async Task<AnnualVacation> GetById(string id)
        {
            return await base._context.AnnualVacations.
                Include(x => x.Vacations).
                Include(x => x.User).
                Where(x => x.Id == id).
                FirstOrDefaultAsync();
        }
        public virtual async Task<IEnumerable<AnnualVacation>> GetByUser(string userId)
        {
            return await base._context.AnnualVacations.
                Include(x => x.Vacations).
                Include(x => x.User).
                Where(x => x.UserId == userId).
                ToListAsync();
        }
        public virtual async Task<IEnumerable<AnnualVacation>> GetByYear(int year)
        {
            return await base._context.AnnualVacations.
                Include(x => x.Vacations).
                Include(x => x.User).
                Where(x => x.Year == year).
                ToListAsync();
        }
        public virtual async Task<IEnumerable<AnnualVacation>> GetByUserYear(int year, string userId)
        {
            return await base._context.AnnualVacations.
                Include(x => x.Vacations).
                Include(x => x.User).
                Where(x => x.Year == year && x.UserId == userId).
                ToListAsync();
        }
    }
}
