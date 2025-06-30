using AMI.EduWork._2025.Domain;
using AMI.EduWork._2025.Domain.Entities;
using AMI.EduWork._2025.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Data.Repository;

public class UserOnProjectRepository : Repository<UserOnProject>, IUserOnProjectRepository
{
    public UserOnProjectRepository(ApplicationDbContext context) : base(context) { }

    public async Task<IEnumerable<UserOnProject>> GetProjectForUsersForIntervalDateTime(string projectId, DateTime startDate, DateTime endDate)
    {
        return await _dbSet
            .Include(oup => oup.User)
            .Include(oup => oup.Project)
            .Where(oup => oup.ProjectId == projectId && oup.RoleStartDate >= startDate && oup.RoleEndDate <= endDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<UserOnProject>> GetProjectsByUserId(string userId)
    {
        return await _dbSet
                .Include(oup => oup.User)
                .Include(oup => oup.Project)
                .ThenInclude(p => p.TimeSlices)
                .Include(oup => oup.Project)
                .ThenInclude(p => p.UsersOnProjects)
                .Where(oup => oup.UserId == userId)
                .ToListAsync();

    }

    public async Task<UserOnProject> GetUserOnProject(string userId, string projectId)
    {
        return await _dbSet
            .Include(oup => oup.User)
            .Include(oup => oup.Project)
            .FirstOrDefaultAsync(oup => oup.UserId == userId && oup.ProjectId == projectId);
    }

    public async Task<IEnumerable<UserOnProject>> GetProjectsForUserForIntervalDateTime(string userId, DateTime startDate, DateTime endDate)
    {
        return await _dbSet
            .Include(oup => oup.User)
            .Include(oup => oup.Project)
            .Where(oup => oup.UserId == userId && oup.RoleStartDate >= startDate && oup.RoleEndDate <= endDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<UserOnProject>> GetUsersByProjectId(string projectId)
    {
        return await _dbSet
            .Include(oup => oup.User)
            .Include(oup => oup.Project)
            .Where(oup => oup.ProjectId == projectId)
            .ToListAsync();
    }

    public Task DeleteByProject(string projectId) {
        return _dbSet
            .Where(oup => oup.ProjectId == projectId)
            .ExecuteDeleteAsync();
    }

    public Task DeleteByUser(string userOnProjectId) {
        return _dbSet
            .Where(oup => oup.Id == userOnProjectId)
            .ExecuteDeleteAsync();
    }

    public async Task<IEnumerable<UserOnProject>> GetProjectsByApplicationUser(ApplicationUser user) {
        return await _dbSet
            .Include(oup => oup.User)
            .Include(oup => oup.Project)
            .Where(oup => oup.UserId == user.Id)
            .ToListAsync();
    }
}

