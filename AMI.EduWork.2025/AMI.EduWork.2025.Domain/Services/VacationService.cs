using AMI.EduWork._2025.Domain.Entities;
using AMI.EduWork._2025.Domain.Interfaces.Repository;
using AMI.EduWork._2025.Domain.Interfaces.Service;
using AMI.EduWork._2025.Domain.Models.VacationModel;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Domain.Services;

public class VacationService : IVacationService
{
    private readonly IVacationRepository _repository;
    private readonly ILogger<VacationService> _logger; 
    public VacationService(IVacationRepository repository, ILogger<VacationService> logger) 
    { 
        _repository = repository;
        _logger = logger;
    }
    
    public async Task<VacationGetModel> GetById(string id)
    {
        AnnualVacation? annualVacation =  await _repository.GetById(id);
        VacationGetModel vacationGetModel = new VacationGetModel();
        
        if (annualVacation == null) return vacationGetModel;

        vacationGetModel = new VacationGetModel{ 
            Id = annualVacation.Id, 
            AvailableVacation = annualVacation.AvailableVacation, 
            PlannedVacation = annualVacation.PlannedVacation, 
            UsedVacation = annualVacation.UsedVacation, 
            Year = annualVacation.Year 
        };        
        
        await _repository.SaveChangesAsync();
        return vacationGetModel;
    }

    public async Task<IEnumerable<VacationGetModel>> GetByYear(int year)
    {
        IEnumerable<AnnualVacation> annualVacations = await _repository.GetAll();
        List<VacationGetModel> vacationGetModels = annualVacations.
            Where(x => x.Year.Equals(year)).
            Select(x=> new VacationGetModel{
                Id=x.Id,
                AvailableVacation=x.AvailableVacation,
                PlannedVacation=x.PlannedVacation,
                UsedVacation=x.UsedVacation,
                Year=x.Year
        }).ToList();

        return vacationGetModels;
    }

    public async Task<IEnumerable<VacationGetModel>> GetAll()
    {
        IEnumerable<AnnualVacation> annualVacations = await _repository.GetAll();
        List<VacationGetModel> vacationGetModels = annualVacations.Select(x => new VacationGetModel
            {
                Id = x.Id,
                AvailableVacation = x.AvailableVacation,
                PlannedVacation = x.PlannedVacation,
                UsedVacation = x.UsedVacation,
                Year = x.Year
            }).ToList();

        return vacationGetModels;
    }

    public async Task<bool> Create(VacationCreateModel? vacationCreateModel)
    {
        if (vacationCreateModel is null) return false;

        AnnualVacation annualVacation = new AnnualVacation{
            Id = Guid.NewGuid().ToString(),
            AvailableVacation = vacationCreateModel.AvailableVacation,
            PlannedVacation = vacationCreateModel.PlannedVacation,
            UsedVacation = vacationCreateModel.UsedVacation,
            Year = vacationCreateModel.Year
        };

        await _repository.Create(annualVacation);
        
        await _repository.SaveChangesAsync();
        return GetById(annualVacation.Id) is not null;
    }

    public async Task<bool> Update(VacationUpdateModel? vacationUpdateModel)
    {
        if (vacationUpdateModel is null) return false;
        AnnualVacation annualVacation = new AnnualVacation
        {
            Id = vacationUpdateModel.Id,
            AvailableVacation = vacationUpdateModel.AvailableVacation,
            PlannedVacation = vacationUpdateModel.PlannedVacation,
            UsedVacation = vacationUpdateModel.UsedVacation,
            Year = vacationUpdateModel.Year
        };

        await _repository.Update(annualVacation);
        
        return await _repository.SaveChangesAsync();
    }

    public async Task<bool> Delete(string id)
    {
        if(_repository.GetById(id) is not null) await _repository.Delete(id);
        return await _repository.SaveChangesAsync();
    }
    
}
