using AMI.EduWork._2025.Domain.Entities;
using AMI.EduWork._2025.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace AMI.EduWork._2025.Data.Repository;

public class VacationRepository : Repository<Vacation>, IVacationRepository
{
    public VacationRepository(ApplicationDbContext context) :base(context) { }

    public override async Task<IEnumerable<Vacation>> GetAll()
    {
        return await base._context.Vacations.Include(x => x.AnnualVacation).ToListAsync();
    }
    public override async Task<Vacation> GetById(string id)
    {
        return await base._context.Vacations.Include(x => x.AnnualVacation).Where(x => x.Id == id).FirstOrDefaultAsync();
    }

}
