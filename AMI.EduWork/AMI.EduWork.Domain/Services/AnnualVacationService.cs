using AMI.EduWork.Domain.Entities;
using AMI.EduWork.Domain.Interfaces.Repository;
using AMI.EduWork.Domain.Interfaces.Service;
using AMI.EduWork.Domain.Models.User;
using AMI.EduWork.Domain.Models.VacationModel;
using Microsoft.Extensions.Logging;

namespace AMI.EduWork._2025.Domain.Services;

public class AnnualVacationService : IAnnualVacationService
{
    private readonly IAnnualVacationRepository _repository;
    private readonly ILogger<AnnualVacationService> _logger;
    public AnnualVacationService(IAnnualVacationRepository repository, ILogger<AnnualVacationService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<AnnualVacationGetModel> GetById(string id)
    {
        AnnualVacation? annualVacation = await _repository.GetById(id);
        AnnualVacationGetModel vacationGetModel = new AnnualVacationGetModel
        {
            Id = annualVacation.Id,
            AvailableVacation = annualVacation.AvailableVacation,
            PlannedVacation = annualVacation.PlannedVacation,
            UsedVacation = annualVacation.UsedVacation,
            Year = annualVacation.Year,
            _GetUserModel = new GetUserModel
            {
                AccessFailedCount = annualVacation.User.AccessFailedCount,
                Email = annualVacation.User.Email,
                TwoFactorEnabled = annualVacation.User.TwoFactorEnabled,
                EmailConfirmed = annualVacation.User.EmailConfirmed,
                Id = annualVacation.User.Id,
                LockoutEnabled = annualVacation.User.LockoutEnabled,
                LockoutEnd = annualVacation.User.LockoutEnd,
                NormalizedEmail = annualVacation.User.NormalizedEmail,
                NormalizedUserName = annualVacation.User.NormalizedUserName,
                PhoneNumber = annualVacation.User.PhoneNumber,
                PhoneNumberConfirmed = annualVacation.User.PhoneNumberConfirmed,
                Role = annualVacation.User.Role,
                UserName = annualVacation.User.UserName
            },
            VacationGetModels = annualVacation.Vacations.Select(x => new VacationGetModels
            {
                EndDate = x.EndDate,
                StartDate = x.StartDate,
                Id = x.Id,
            }).ToList()
        };

        return vacationGetModel;
    }

    public async Task<IEnumerable<AnnualVacationGetModel>> GetAll()
    {
        IEnumerable<AnnualVacation> annualVacations = await _repository.GetAll();
        IEnumerable<AnnualVacationGetModel> vacationGetModels = annualVacations.Select(x => new AnnualVacationGetModel
        {
            Id = x.Id,
            AvailableVacation = x.AvailableVacation,
            PlannedVacation = x.PlannedVacation,
            UsedVacation = x.UsedVacation,
            Year = x.Year,
            _GetUserModel = new GetUserModel
            {
                AccessFailedCount = x.User.AccessFailedCount,
                Email = x.User.Email,
                TwoFactorEnabled = x.User.TwoFactorEnabled,
                EmailConfirmed = x.User.EmailConfirmed,
                Id = x.User.Id,
                LockoutEnabled = x.User.LockoutEnabled,
                LockoutEnd = x.User.LockoutEnd,
                NormalizedEmail = x.User.NormalizedEmail,
                NormalizedUserName = x.User.NormalizedUserName,
                PhoneNumber = x.User.PhoneNumber,
                PhoneNumberConfirmed = x.User.PhoneNumberConfirmed,
                Role = x.User.Role,
                UserName = x.User.UserName
            },
            VacationGetModels = x.Vacations.Select(y => new VacationGetModels
            {
                EndDate = y.EndDate,
                StartDate = y.StartDate,
                Id = y.Id,
            }).ToList()
        });

        return vacationGetModels;
    }
    public async Task<IEnumerable<AnnualVacationGetModel>> GetByYear(int year)
    {
        IEnumerable<AnnualVacation> annualVacations = await _repository.GetAll();
        IEnumerable<AnnualVacationGetModel> vacationGetModels = annualVacations.Where(x => x.Year == year).Select(x => new AnnualVacationGetModel
        {
            Id = x.Id,
            AvailableVacation = x.AvailableVacation,
            PlannedVacation = x.PlannedVacation,
            UsedVacation = x.UsedVacation,
            Year = x.Year,
            _GetUserModel = new GetUserModel
            {
                AccessFailedCount = x.User.AccessFailedCount,
                Email = x.User.Email,
                TwoFactorEnabled = x.User.TwoFactorEnabled,
                EmailConfirmed = x.User.EmailConfirmed,
                Id = x.User.Id,
                LockoutEnabled = x.User.LockoutEnabled,
                LockoutEnd = x.User.LockoutEnd,
                NormalizedEmail = x.User.NormalizedEmail,
                NormalizedUserName = x.User.NormalizedUserName,
                PhoneNumber = x.User.PhoneNumber,
                PhoneNumberConfirmed = x.User.PhoneNumberConfirmed,
                Role = x.User.Role,
                UserName = x.User.UserName
            },
            VacationGetModels = x.Vacations.Select(y => new VacationGetModels
            {
                EndDate = y.EndDate,
                StartDate = y.StartDate,
                Id = y.Id,
            }).ToList()
        });

        return vacationGetModels;
    }

    public async Task<bool> Create(AnnualVacationCreateModel? annualVacationCreateModel)
    {
        if (annualVacationCreateModel is null) return false;

        AnnualVacation annualVacation = new AnnualVacation
        {
            Id = Guid.NewGuid().ToString(),
            AvailableVacation = annualVacationCreateModel.AvailableVacation,
            PlannedVacation = annualVacationCreateModel.PlannedVacation,
            UsedVacation = annualVacationCreateModel.UsedVacation,
            Year = annualVacationCreateModel.Year,
            UserId = annualVacationCreateModel.UserId
        };

        await _repository.Create(annualVacation);
        return await _repository.SaveChangesAsync();
    }

    public async Task<bool> Update(AnnualVacationUpdateModel? vacationUpdateModel)
    {
        if (vacationUpdateModel is null) return false;
        AnnualVacation annualVacation = await _repository.GetById(vacationUpdateModel.Id);
        annualVacation.Id = vacationUpdateModel.Id;
        annualVacation.AvailableVacation = vacationUpdateModel.AvailableVacation;
        annualVacation.PlannedVacation = vacationUpdateModel.PlannedVacation;
        annualVacation.UsedVacation = vacationUpdateModel.UsedVacation;
        annualVacation.Year = vacationUpdateModel.Year;

        await _repository.Update(annualVacation);
        return await _repository.SaveChangesAsync();
    }

    public async Task<bool> Delete(string id)
    {
        await _repository.Delete(id);
        return await _repository.SaveChangesAsync();
    }

}
