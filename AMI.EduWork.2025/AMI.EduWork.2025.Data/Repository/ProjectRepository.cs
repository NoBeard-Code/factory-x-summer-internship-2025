using AMI.EduWork._2025.Domain.Entities;
using AMI.EduWork._2025.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Data.Repository;

public class ProjectRepository : Repository<Project> , IProjectRepository
{
    public ProjectRepository(ApplicationDbContext context) :base(context) { }

    public async Task<IEnumerable<Project>> GetAllProjectsByUserId(string userId) {
        var projects = await _dbSet
            .Where(p => p.UsersOnProjects.Any(up => up.UserId == userId))
            .ToListAsync();
        return projects;
    }

    public async Task<Project> GetProjectByName(string name) {
        var projects = await _dbSet.Where(p => p.Name == name).FirstOrDefaultAsync();
        if (projects == null) {
            throw new KeyNotFoundException($"Project with name '{name}' not found.");
        }
        return projects;
    }

    public async Task<IEnumerable<Project>> GetProjectsByDateRange(DateTime startDate, DateTime endDate) {
        var projects =await _dbSet
            .Where(p => p.TimeSlices.Any(ts => ts.Start >= startDate && ts.End <= endDate))
            .ToListAsync();
        return projects;
    }

    public async Task<bool> ProjectExists(string name) {
        var project = await _dbSet.FirstOrDefaultAsync(p => p.Name == name);
        if (project == null) { 
            throw new KeyNotFoundException($"Project with name '{name}' not found.");
        }
        return true;
    }
}
