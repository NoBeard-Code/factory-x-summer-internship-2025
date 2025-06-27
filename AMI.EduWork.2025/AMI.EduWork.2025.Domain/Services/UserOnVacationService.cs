using AMI.EduWork._2025.Domain.Entities;
using AMI.EduWork._2025.Domain.Interfaces.Repository;
using AMI.EduWork._2025.Domain.Interfaces.Service;
using AMI.EduWork._2025.Domain.Models.User;
using AMI.EduWork._2025.Domain.Models.UserOnVacationModel;
using AMI.EduWork._2025.Domain.Models.VacationModel;
using Microsoft.Extensions.Logging;

namespace AMI.EduWork._2025.Domain.Services;

public class UserOnVacationService : IUserOnVacationService
{
    private readonly IUserOnVacationRepository _repository;
    private readonly IVacationService _vacationService;
    private readonly ILogger<UserOnVacationService> _logger;
    private readonly IUserService _userService;
    public UserOnVacationService(
        IUserOnVacationRepository userOnVacationRepository, 
        IVacationService annualVacationService, 
        IUserService userService,
        ILogger<UserOnVacationService> logger)
    {
        _logger = logger;
        _repository = userOnVacationRepository;
        _vacationService = annualVacationService;
        _userService = userService;
    }
    public async Task<bool> Create(UserOnVacationCreateModel? userOnVacationCreateModel)
    {
        if (userOnVacationCreateModel is null) return false;

        UserOnVacation userOnVacation = new UserOnVacation {
            Id = Guid.NewGuid().ToString(),
            StartDate = userOnVacationCreateModel.StartDate,
            EndDate = userOnVacationCreateModel.EndDate,
            UserId = userOnVacationCreateModel.UserId,
            AnnualVacationId = userOnVacationCreateModel.AnnualVacationId,
        };

        await _repository.Create( userOnVacation );
        return await _repository.SaveChangesAsync();
    }

    public async Task<bool> Delete(string id)
    {
        UserOnVacation userOnVacation = await _repository.GetById(id);
        if (userOnVacation is null) return false;
        await _repository.Delete(id);
        return await _repository.SaveChangesAsync();
    }

    public async Task<UserOnVacationGetModel> GetById(string id)
    {
        UserOnVacation userOnVacation = await _repository.GetById(id);
        if (userOnVacation is null) return new UserOnVacationGetModel();

        GetUserModel getUserModel = await _userService.GetById(userOnVacation.UserId);
        VacationGetModel vacationGetModel = await _vacationService.GetById(userOnVacation.AnnualVacationId);
        UserOnVacationGetModel userOnVacationGetModel = new UserOnVacationGetModel
        {
            Id = userOnVacation.Id,
            StartDate = userOnVacation.StartDate,
            EndDate = userOnVacation.EndDate,
            _VacationGetModel = vacationGetModel,
            _GetUserModel = getUserModel
            
        };

        return userOnVacationGetModel;
    }
    public async Task<IEnumerable<UserOnVacationGetModel>> GetByDateTime(DateTime date)
    {
        IEnumerable<UserOnVacation> userOnVacation = await _repository.GetAll();
        IEnumerable<UserOnVacationGetModel> userOnVacationGetModel = userOnVacation.
            Where(v => v.StartDate>=date || v.EndDate<=date).
            Select(v => new UserOnVacationGetModel
            {
                Id = v.Id,
                StartDate = v.StartDate,
                EndDate = v.EndDate,
                _VacationGetModel = new VacationGetModel { 
                    Id = v.AnnualVacationId, 
                    AvailableVacation = v.AnnualVacation.AvailableVacation,
                    PlannedVacation = v.AnnualVacation.PlannedVacation,
                    UsedVacation = v.AnnualVacation.UsedVacation,
                    Year  = v.AnnualVacation.Year
                },
                _GetUserModel = new GetUserModel{
                    Id = v.UserId,
                    AccessFailedCount = v.User.AccessFailedCount,
                    Email = v.User.Email,
                    EmailConfirmed = v.User.EmailConfirmed,
                    LockoutEnabled = v.User.LockoutEnabled,
                    TwoFactorEnabled = v.User.TwoFactorEnabled,
                    LockoutEnd = v.User.LockoutEnd,
                    NormalizedEmail = v.User.NormalizedEmail,
                    NormalizedUserName = v.User.NormalizedUserName,
                    PhoneNumber = v.User.PhoneNumber,
                    PhoneNumberConfirmed = v.User.PhoneNumberConfirmed,
                    Role = v.User.Role,
                    UserName = v.User.UserName
                }
            });
        return userOnVacationGetModel;
    }
    public async Task<IEnumerable<UserOnVacationGetModel>> GetByUserIdYear(string UserId, int year)
    {
        IEnumerable<UserOnVacation> userOnVacation = await _repository.GetAll();
        IEnumerable<UserOnVacationGetModel> userOnVacationGetModel = userOnVacation.
            Where(v => v.UserId == UserId && v.AnnualVacation.Year == year).
            Select(v => new UserOnVacationGetModel
            {
                Id = v.Id,
                StartDate = v.StartDate,
                EndDate = v.EndDate,
                _VacationGetModel = new VacationGetModel
                {
                    Id = v.AnnualVacationId,
                    AvailableVacation = v.AnnualVacation.AvailableVacation,
                    PlannedVacation = v.AnnualVacation.PlannedVacation,
                    UsedVacation = v.AnnualVacation.UsedVacation,
                    Year = v.AnnualVacation.Year
                },
                _GetUserModel = new GetUserModel
                {
                    Id = v.UserId,
                    AccessFailedCount = v.User.AccessFailedCount,
                    Email = v.User.Email,
                    EmailConfirmed = v.User.EmailConfirmed,
                    LockoutEnabled = v.User.LockoutEnabled,
                    TwoFactorEnabled = v.User.TwoFactorEnabled,
                    LockoutEnd = v.User.LockoutEnd,
                    NormalizedEmail = v.User.NormalizedEmail,
                    NormalizedUserName = v.User.NormalizedUserName,
                    PhoneNumber = v.User.PhoneNumber,
                    PhoneNumberConfirmed = v.User.PhoneNumberConfirmed,
                    Role = v.User.Role,
                    UserName = v.User.UserName
                }
            });
        return userOnVacationGetModel;
    }
    public async Task<IEnumerable<UserOnVacationGetModel>> GetByUser(string UserId)
    {
        IEnumerable<UserOnVacation> userOnVacation = await _repository.GetAll();
        IEnumerable<UserOnVacationGetModel> userOnVacationGetModel = userOnVacation.
            Where(v => v.UserId == UserId).
            Select(v => new UserOnVacationGetModel
            {
                Id = v.Id,
                StartDate = v.StartDate,
                EndDate = v.EndDate,
                _VacationGetModel = new VacationGetModel
                {
                    Id = v.AnnualVacationId,
                    AvailableVacation = v.AnnualVacation.AvailableVacation,
                    PlannedVacation = v.AnnualVacation.PlannedVacation,
                    UsedVacation = v.AnnualVacation.UsedVacation,
                    Year = v.AnnualVacation.Year
                },
                _GetUserModel = new GetUserModel
                {
                    Id = v.UserId,
                    AccessFailedCount = v.User.AccessFailedCount,
                    Email = v.User.Email,
                    EmailConfirmed = v.User.EmailConfirmed,
                    LockoutEnabled = v.User.LockoutEnabled,
                    TwoFactorEnabled = v.User.TwoFactorEnabled,
                    LockoutEnd = v.User.LockoutEnd,
                    NormalizedEmail = v.User.NormalizedEmail,
                    NormalizedUserName = v.User.NormalizedUserName,
                    PhoneNumber = v.User.PhoneNumber,
                    PhoneNumberConfirmed = v.User.PhoneNumberConfirmed,
                    Role = v.User.Role,
                    UserName = v.User.UserName
                }
            });
        return userOnVacationGetModel;
    }
    public async Task<IEnumerable<UserOnVacationGetModel>> GetAll()
    {
        IEnumerable<UserOnVacation> userOnVacation = await _repository.GetAll();
        IEnumerable<UserOnVacationGetModel> userOnVacationGetModel = userOnVacation.Select(v => new UserOnVacationGetModel
            {
                Id = v.Id,
                StartDate = v.StartDate,
                EndDate = v.EndDate,
                _VacationGetModel = new VacationGetModel
                {
                    Id = v.AnnualVacationId,
                    AvailableVacation = v.AnnualVacation.AvailableVacation,
                    PlannedVacation = v.AnnualVacation.PlannedVacation,
                    UsedVacation = v.AnnualVacation.UsedVacation,
                    Year = v.AnnualVacation.Year
                },
                _GetUserModel = new GetUserModel
                {
                    Id = v.UserId,
                    AccessFailedCount = v.User.AccessFailedCount,
                    Email = v.User.Email,
                    EmailConfirmed = v.User.EmailConfirmed,
                    LockoutEnabled = v.User.LockoutEnabled,
                    TwoFactorEnabled = v.User.TwoFactorEnabled,
                    LockoutEnd = v.User.LockoutEnd,
                    NormalizedEmail = v.User.NormalizedEmail,
                    NormalizedUserName = v.User.NormalizedUserName,
                    PhoneNumber = v.User.PhoneNumber,
                    PhoneNumberConfirmed = v.User.PhoneNumberConfirmed,
                    Role = v.User.Role,
                    UserName = v.User.UserName
                }
            });
        return userOnVacationGetModel;
    }

    public async Task<bool> Update(UserOnVacationUpdateModel? userOnVacationUpdateModel)
    {
        if (userOnVacationUpdateModel is null) return false;
        UserOnVacation userOnVacation = await _repository.GetById(userOnVacationUpdateModel.Id);
        userOnVacation.Id = userOnVacationUpdateModel.Id;
        userOnVacation.UserId = userOnVacationUpdateModel.UserId;
        userOnVacation.AnnualVacationId = userOnVacationUpdateModel.AnnualVacationId;
        userOnVacation.StartDate = userOnVacationUpdateModel.StartDate;
        userOnVacation.EndDate = userOnVacationUpdateModel.EndDate;

        await _repository.Update(userOnVacation);
        return await _repository.SaveChangesAsync();
    }

}
