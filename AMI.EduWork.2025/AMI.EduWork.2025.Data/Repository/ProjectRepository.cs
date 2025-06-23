using AMI.EduWork._2025.Domain.Entities;
using AMI.EduWork._2025.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Data.Repository;

using AMI.EduWork._2025.Domain.Entities;
using AMI.EduWork._2025.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

public class ProjectRepository : Repository<Project>, IProjectRepository {
    public ProjectRepository(ApplicationDbContext context) : base(context) { }



    public async Task<Project> GetProjectByName(string name) {
        var project = await _dbSet
            .Include(p => p.UsersOnProjects)
                .ThenInclude(uop => uop.User)
            .Include(p => p.TimeSlices)
                .ThenInclude(ts => ts.User)
            .Include(p => p.TimeSlices)
                .ThenInclude(ts => ts.WorkDay)
            .FirstOrDefaultAsync(p => p.Name == name);

        if (project == null) {
            throw new KeyNotFoundException($"Project with name '{name}' not found.");
        }

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

