using AMI.EduWork._2025.Data.Entities;
using AMI.EduWork._2025.Data.Repository;
using AMI.EduWork._2025.Domain.Models.VacationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Domain.Services
{
    public class VacationService
    {
        private readonly AnnualVacationRepository _repository;
        public VacationService(AnnualVacationRepository repository) 
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

            return vacationGetModel;
        }

        public bool Create(VacationCreateModel? vacationCreateModel)
        {
            if (vacationCreateModel is null) return false;

            AnnualVacation annualVacation = new AnnualVacation{
                Id = Guid.NewGuid().ToString(),
                AvailableVacation = vacationCreateModel.AvailableVacation,
                PlannedVacation = vacationCreateModel.PlannedVacation,
                UsedVacation = vacationCreateModel.UsedVacation,
                Year = vacationCreateModel.Year
            };

            _repository.Create(annualVacation);
            
            return GetById(annualVacation.Id) is not null;
        }

        public bool Update(VacationUpdateModel? vacationUpdateModel)
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

            _repository.Update(annualVacation);
            return Equals(_repository.GetById(annualVacation.Id), vacationUpdateModel); 
        }

        public bool Delete(string id)
        {
            if(_repository.GetById(id) is not null) _repository.Delete(id);
            return _repository.GetById(id) is null;
        }
        
    }
}
