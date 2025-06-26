using AMI.EduWork._2025.Domain.Entities;
using AMI.EduWork._2025.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Data.Repository;

public class UserOnVacationRepository : Repository<UserOnVacation>, IUserOnVacationRepository
{
    public UserOnVacationRepository(ApplicationDbContext context) :base(context) { }

    public override async Task<IEnumerable<UserOnVacation>> GetAll()
    {
        return await base._context.UsersOnVacations.Include(x => x.User).Include(x => x.AnnualVacation).ToListAsync();
    }
    public override async Task<UserOnVacation> GetById(string id)
    {
        return await base._context.UsersOnVacations.Include(x => x.User).Include(x => x.AnnualVacation).Where(x => x.Id == id).FirstOrDefaultAsync();
    }

}
