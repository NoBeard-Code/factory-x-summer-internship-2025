using AMI.EduWork.Domain.Entities;
using AMI.EduWork.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork.Data.Repository;

using AMI.EduWork.Domain.Entities;
using AMI.EduWork.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

public class ProjectRepository : Repository<Project>, IProjectRepository {
    public ProjectRepository(ApplicationDbContext context) : base(context) { }

    public async Task<IEnumerable<Project>> GetAllUserProjects(string userId)
    {
        return await _dbSet
           .Where(p => p.UsersOnProjects.Any(uop => uop.UserId == userId))
           .ToListAsync();
    }

    public async Task<Project?> GetProjectByName(string name) {
        var project = await _dbSet
            .Include(p => p.UsersOnProjects)
                .ThenInclude(uop => uop.User)
            .Include(p => p.TimeSlices)
                .ThenInclude(ts => ts.User)
            .Include(p => p.TimeSlices)
                .ThenInclude(ts => ts.WorkDay)
            .FirstOrDefaultAsync(p => p.Name == name);

       

        return project;
    }

    public async Task<IEnumerable<Project>> GetProjectsByDateRange(DateTime startDate, DateTime endDate) {
        return await _dbSet
            .Include(p => p.UsersOnProjects)
                .ThenInclude(uop => uop.User)
            .Include(p => p.TimeSlices)
                .ThenInclude(ts => ts.User)
            .Include(p => p.TimeSlices)
                .ThenInclude(ts => ts.WorkDay)
            .Where(p => p.TimeSlices.Any(ts => ts.Start >= startDate && ts.End <= endDate))
            .ToListAsync();
    }

    public async Task<bool> ProjectExists(string name) {
        return await _dbSet.AnyAsync(p => p.Name == name);
    }
}

