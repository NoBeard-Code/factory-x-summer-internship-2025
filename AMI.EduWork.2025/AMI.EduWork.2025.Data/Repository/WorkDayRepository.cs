using AMI.EduWork._2025.Domain.Entities;
using AMI.EduWork._2025.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Data.Repository;

public class WorkDayRepository : Repository<WorkDay>, IWorkDayRepository
{
    public WorkDayRepository(ApplicationDbContext context) : base(context) { }

    public async Task<bool> DayExists(DateTime date)
    {
        return await _dbSet.AnyAsync(wd => wd.Date == date);
    }

    public async Task<WorkDay> GetByDate(DateTime date)
    {
        return await _dbSet.FirstOrDefaultAsync(wd => wd.Date == date);
    }
}
