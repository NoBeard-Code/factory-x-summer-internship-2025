using AMI.EduWork.Domain.Entities;
using AMI.EduWork.Domain.Interfaces.Repository;
using AMI.EduWork.Domain.Interfaces.Service;
using AMI.EduWork.Domain.Models.AnnualVacationModel;
using AMI.EduWork.Domain.Models.User;
using AMI.EduWork.Domain.Models.UserOnVacationModel;
using AMI.EduWork.Domain.Models.VacationModel;
using Microsoft.Extensions.Logging;

namespace AMI.EduWork.Domain.Services;

public class VacationService : IVacationService
{
    private readonly IVacationRepository _repository;
    private readonly ILogger<VacationService> _logger;
    public VacationService(
        IVacationRepository userOnVacationRepository, 
        ILogger<VacationService> logger)
    {
        _logger = logger;
        _repository = userOnVacationRepository;
    }
    public async Task<bool> Create(VacationCreateModel? vacationCreateModel)
    {
        if (vacationCreateModel is null) return false;

        Vacation vacation = new Vacation {
            Id = Guid.NewGuid().ToString(),
            StartDate = vacationCreateModel.StartDate,
            EndDate = vacationCreateModel.EndDate,
            AnnualVacationId = vacationCreateModel.AnnualVacationId
        };

        await _repository.Create(vacation);
        return await _repository.SaveChangesAsync();
    }

    public async Task<bool> Delete(string id)
    {
        Vacation vacation = await _repository.GetById(id);
        if (vacation is null) return false;
        await _repository.Delete(id);
        return await _repository.SaveChangesAsync();
    }

    public async Task<VacationGetModel> GetById(string id)
    {
        Vacation vacation = await _repository.GetById(id);
        if (vacation is null) return new VacationGetModel();

        VacationGetModel vacationGetModel = new VacationGetModel
        {
            Id = vacation.Id,
            StartDate = vacation.StartDate,
            EndDate = vacation.EndDate,
            _AnnualVacationGetModel = new AnnualVacationGetVacationModel
            {
                Id = vacation.AnnualVacation.Id,
                AvailableVacation = vacation.AnnualVacation.AvailableVacation,
                PlannedVacation = vacation.AnnualVacation.PlannedVacation,
                UsedVacation = vacation.AnnualVacation.UsedVacation,
                UserId = vacation.AnnualVacation.UserId,
                Year = vacation.AnnualVacation.Year
            }
        };
        return vacationGetModel;
    }
    public async Task<IEnumerable<VacationGetModel>> GetAll()
    {
        IEnumerable<Vacation> vacation = await _repository.GetAll();
        IEnumerable<VacationGetModel> vacationGetModel = vacation.Select(v => new VacationGetModel
            {
                Id = v.Id,
                StartDate = v.StartDate,
                EndDate = v.EndDate,
                _AnnualVacationGetModel = new AnnualVacationGetVacationModel
                {
                    Id = v.AnnualVacationId,
                    AvailableVacation = v.AnnualVacation.AvailableVacation,
                    PlannedVacation = v.AnnualVacation.PlannedVacation,
                    UsedVacation = v.AnnualVacation.UsedVacation,
                    Year = v.AnnualVacation.Year,
                    UserId = v.AnnualVacation.UserId
                },
            });
        return vacationGetModel;
    }

    public async Task<bool> Update(VacationUpdateModel? vacationUpdateModel)
    {
        if (vacationUpdateModel is null) return false;
        Vacation vacation = await _repository.GetById(vacationUpdateModel.Id);
        vacation.Id = vacationUpdateModel.Id;
        vacation.AnnualVacationId = vacationUpdateModel.AnnualVacationId;
        vacation.StartDate = vacationUpdateModel.StartDate;
        vacation.EndDate = vacationUpdateModel.EndDate;

        await _repository.Update(vacation);
        return await _repository.SaveChangesAsync();
    }

}
