using AMI.EduWork._2025.Domain.Entities;
using AMI.EduWork._2025.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Data.Repository;

public class UserOnProjectRepository: Repository<UserOnProject> , IUserOnProjectRepository
{
    public UserOnProjectRepository(ApplicationDbContext context) : base(context) { }

    public async Task<IEnumerable<UserOnProject>> GetProjectForUsersForIntervalDateTime(string projectId, DateTime startDate, DateTime endDate) {
        var userOnProjects = await _dbSet
            .Where(oup => oup.ProjectId == projectId && oup.RoleStartDate >= startDate && oup.RoleEndDate <= endDate).ToListAsync();
        return userOnProjects;
    }

    public async Task<IEnumerable<UserOnProject>> GetProjectsByUserId(string userId) {
        var userOnProjects = await _dbSet
            .Where(oup => oup.UserId == userId).ToListAsync();
        return userOnProjects;
    }

    public async Task<UserOnProject> GetUserOnProject(string userId, string projectId) {
            var userOnProject = await _dbSet
            .FirstOrDefaultAsync(oup => oup.UserId == userId && oup.ProjectId == projectId);
        return userOnProject;
    }

    public async Task<IEnumerable<UserOnProject>> GetProjectsForUserForIntervalDateTime(string userId, DateTime startDate, DateTime endDate) {
        var userOnProjects = await _dbSet
            .Where(oup => oup.UserId == userId && oup.RoleStartDate >= startDate && oup.RoleEndDate <= endDate).ToListAsync();
        return userOnProjects;
    }

    public async Task<IEnumerable<UserOnProject>> GetUsersByProjectId(string projectId) {
        var userOnProjects = await _dbSet.Where(oup => projectId == oup.ProjectId).ToListAsync();
        return userOnProjects;

    }
}
