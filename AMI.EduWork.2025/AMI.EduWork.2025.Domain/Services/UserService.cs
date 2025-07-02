using AMI.EduWork._2025.Domain.Entities;
using AMI.EduWork._2025.Domain.Interfaces.Repository;
using AMI.EduWork._2025.Domain.Interfaces.Service;
using AMI.EduWork._2025.Domain.Models.TimeSlice;
using AMI.EduWork._2025.Domain.Models.User;
using AMI.EduWork._2025.Domain.Models.WorkDay;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Data;

namespace AMI.EduWork._2025.Domain.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly ILogger<UserService> _logger;
    private readonly IMapper _mapper;
    public UserService(IUserRepository repository, ILogger<UserService> logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<bool> Delete(string id)
    {
        if (id is null)
        {
            _logger.LogWarning("Attempted to delete User with null Id");
            return false;
        }
        try
        {
            await _repository.Delete(id);
            bool result = await _repository.SaveChangesAsync();
            if (result) _logger.LogInformation("Successfully deleted User.");
            else _logger.LogWarning("No changes saved when deleting User.");

            return result;

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while deleting User with Id: {Id}.", id);
            throw;
        }
    }

    public async Task<IEnumerable<GetUserModel>> GetAll()
    {
        IEnumerable<ApplicationUser> entity = await _repository.GetAll();
        List<GetUserModel> users = _mapper.Map<List<GetUserModel>>(entity);
        return users;
    }

    public async Task<GetUserModel> GetById(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            _logger.LogWarning("Attempted to retrieve User with null Id");
            return null;
        }
        ApplicationUser entity = await _repository.GetById(id);
        if (entity is null)
        {
            _logger.LogWarning("User with Id {Id} doesn't exist", id);
            return null;
        }
        GetUserModel user = _mapper.Map<GetUserModel>(entity);
        return user;
    }

    public async Task<bool> Update(GetUserModel entity)
    {
        if (entity is null)
        {
            _logger.LogWarning("Attempted to update User with null entity");
            return false;
        }

        try
        {
            ApplicationUser existing = await _repository.GetById(entity.Id);
            if (existing is null)
            {
                _logger.LogWarning("User with Id {Id} not found for update.", entity.Id);
                return false;
            }
            if (entity.UserName != null)
                existing.UserName = entity.UserName;

            if (entity.NormalizedUserName != null)
                existing.NormalizedUserName = entity.NormalizedUserName;

            if (entity.Email != null)
                existing.Email = entity.Email;

            if (entity.NormalizedEmail != null)
                existing.NormalizedEmail = entity.NormalizedEmail;

            if (entity.PhoneNumber != null)
                existing.PhoneNumber = entity.PhoneNumber;

            if (entity.Role != existing.Role)
                existing.Role = entity.Role;

            await _repository.Update(existing);

            bool result = await _repository.SaveChangesAsync();
            if (result)
                _logger.LogInformation("Successfully updated User with Id {Id}.", existing.Id);
            else
                _logger.LogWarning("No changes saved when updating User with Id {Id}.", existing.Id);

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while updating User with Id {Id}.", entity.Id);
            throw;
        }
    }
}
