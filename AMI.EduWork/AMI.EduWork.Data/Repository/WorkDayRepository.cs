﻿using AMI.EduWork.Domain.Entities;
using AMI.EduWork.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace AMI.EduWork.Data.Repository;

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
