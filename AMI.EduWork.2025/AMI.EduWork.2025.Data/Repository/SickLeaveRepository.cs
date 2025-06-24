using AMI.EduWork._2025.Domain.Entities;
using AMI.EduWork._2025.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace AMI.EduWork._2025.Data.Repository;

public class SickLeaveRepository : Repository<SickLeave>, ISickLeaveRepository {
    public SickLeaveRepository(ApplicationDbContext context) : base(context) { }

    public async Task<IEnumerable<SickLeave>> GetAllByDate(DateOnly startDate, DateOnly endDate) {
        return await _dbSet
            .Include(sl => sl.User)
            .Where(sl => sl.StartDate >= startDate && sl.EndDate <= endDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<SickLeave>> GetAllByDateForUser(string userId, DateOnly startDate, DateOnly endDate) {
        return await _dbSet
            .Include(sl => sl.User)
            .Where(sl => sl.UserId == userId && sl.StartDate >= startDate && sl.EndDate <= endDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<SickLeave>> GetByUserId(string userId) {
        return await _dbSet
            .Include(sl => sl.User)
            .Where(sl => sl.UserId == userId)
            .ToListAsync();
    }
}
