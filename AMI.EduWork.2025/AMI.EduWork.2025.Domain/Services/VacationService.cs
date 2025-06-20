using AMI.EduWork._2025.Domain.Entities;
using AMI.EduWork._2025.Domain.Interfaces.Repository;
using AMI.EduWork._2025.Domain.Models.VacationModel;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Domain.Services;

public class VacationService
{
    private readonly IAnnualVacationRepository _repository;
    public VacationService(IAnnualVacationRepository repository) 
    { 
        _repository = repository;
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
        if(_repository.GetById(id) is not null) _repository.Delete(id);
        return await _repository.SaveChangesAsync();
    }
    
}
