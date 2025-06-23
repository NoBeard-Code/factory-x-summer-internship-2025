using AMI.EduWork._2025.Domain.Entities;
using AMI.EduWork._2025.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Data.Repository;

public class SickLeaveRepository : Repository<SickLeave>, ISickLeaveRepository {
    public SickLeaveRepository(ApplicationDbContext context) : base(context) { }

    public async Task<IEnumerable<SickLeave>> GetAllByDate(DateOnly startDate, DateOnly endDate) {
        var sickLeaves = await  _dbSet.Where(sl => sl.StartDate >= startDate && sl.EndDate <= endDate).ToListAsync();
        return sickLeaves;
    }

    public async Task<IEnumerable<SickLeave>> GetAllByDateForUser(string userId, DateOnly startDate, DateOnly endDate) {
        var sickLeaves = await _dbSet
            .Where(sl => sl.UserId == userId && sl.StartDate >= startDate && sl.EndDate <= endDate)
            .ToListAsync();
        return sickLeaves;
    }

    public async Task<IEnumerable<SickLeave>> GetByUserId(string userId) {
         var sickLeaves = await _dbSet
            .Where(sl => sl.UserId == userId)
            .ToListAsync();
        return sickLeaves;
    }
}
