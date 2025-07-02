using AMI.EduWork.Domain.Entities;
using AMI.EduWork.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace AMI.EduWork.Data.Repository;

public class TimeSliceRepository : Repository<TimeSlice>, ITimeSliceRepository
{
    public TimeSliceRepository(ApplicationDbContext context) : base(context) { }

    public async Task<IEnumerable<TimeSlice>> GetAllUserTimeSlices(string userId)
    {
        return await _dbSet.Where(ts => ts.UserId == userId)
            .Include(ts => ts.WorkDay)
            .Include(ts => ts.User).ToListAsync();
    }

    public async Task<IEnumerable<TimeSlice>> GetAllUserTimeSlicesByDate(string userId, DateTime date)
    {
        return await _dbSet
            .Include(ts => ts.User)
            .Include(ts => ts.WorkDay)
            .Include(ts => ts.Project)
            .Where(ts => ts.UserId == userId && ts.WorkDay.Date == date.Date)
            .ToListAsync();
    }

    public async override Task<TimeSlice> GetById(string id)
    {
        return await _dbSet.Include(ts => ts.WorkDay)
            .Include(ts => ts.User)
            .SingleOrDefaultAsync(ts => ts.Id == id);
    }

}
