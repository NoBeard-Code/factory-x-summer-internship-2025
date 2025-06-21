using AMI.EduWork._2025.Domain.Interfaces.Repository;
using AMI.EduWork._2025.Domain.Interfaces.Service;
using AMI.EduWork._2025.Domain.Models.ContractModel;
using System.Collections.Generic;

namespace AMI.EduWork._2025.Domain.Services
{
    public class ContractService : IContractService
    {
        private readonly IContractRepository _repository;
        public ContractService(IContractRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Create(ContractCreateModel contractCreateModel)
        {
            Entities.Contract contract = new Entities.Contract {
                Id = Guid.NewGuid().ToString(),
                HourlyRate = contractCreateModel.HourlyRate,
                IsActive = contractCreateModel.IsActive,
                WorkingHour = contractCreateModel.WorkingHour
            };
            await _repository.Create(contract);    
            return await _repository.SaveChangesAsync();
        }

        public async Task<bool> Delete(string id)
        {
            await _repository.Delete(id);
            return await _repository.SaveChangesAsync();
        }

        public async Task<ContractGetByIdModel> GetById(string id)
        {
            Entities.Contract contract = await _repository.GetById(id);
            ContractGetByIdModel contractGetByIdModel = new ContractGetByIdModel {
                Id = contract.Id,
                HourlyRate = contract.HourlyRate,
                IsActive= contract.IsActive,
                WorkingHour= contract.WorkingHour
            };
            return contractGetByIdModel;
        }

        public async Task<IEnumerable<ContractGetByIdModel>> GetByIsActive()
        {
            IEnumerable<Entities.Contract> contract = await _repository.GetAll();
            List<ContractGetByIdModel> contractGetByIdModel = contract.
                Where(x => x.IsActive).
                Select(x => new ContractGetByIdModel
                {
                    Id = x.Id,
                    HourlyRate= x.HourlyRate,
                    IsActive = x.IsActive,
                    WorkingHour = x.WorkingHour
                }).ToList();

            return contractGetByIdModel;
        }

        public async Task<IEnumerable<ContractGetByIdModel>> GetByHourlyRate(int hourlyRate)
        {
            IEnumerable<Entities.Contract> contract = await _repository.GetAll();
            List<ContractGetByIdModel> contractGetByIdModel = contract.
                Where(x => x.HourlyRate.Equals(hourlyRate)).
                Select(x => new ContractGetByIdModel
                {
                    Id = x.Id,
                    HourlyRate = x.HourlyRate,
                    IsActive = x.IsActive,
                    WorkingHour = x.WorkingHour
                }).ToList();

            return contractGetByIdModel;
        }
        public async Task<IEnumerable<ContractGetByIdModel>> GetByWorkingHour(int workingHour)
        {
            IEnumerable<Entities.Contract> contract = await _repository.GetAll();
            List<ContractGetByIdModel> contractGetByIdModel = contract.
                Where(x => x.WorkingHour.Equals(workingHour)).
                Select(x => new ContractGetByIdModel
                {
                    Id = x.Id,
                    HourlyRate = x.HourlyRate,
                    IsActive = x.IsActive,
                    WorkingHour = x.WorkingHour
                }).ToList();

            return contractGetByIdModel;
        }
        public async Task<IEnumerable<ContractGetByIdModel>> GetAll()
        {
            IEnumerable<Entities.Contract> contract = await _repository.GetAll();
            List<ContractGetByIdModel> contractGetByIdModel = contract.Select(x => new ContractGetByIdModel
                {
                    Id = x.Id,
                    HourlyRate = x.HourlyRate,
                    IsActive = x.IsActive,
                    WorkingHour = x.WorkingHour
                }).ToList();

            return contractGetByIdModel;
        }

        public async Task<bool> Update(ContractUpdateModel contractUpdateModel)
        {
            Entities.Contract contract = new Entities.Contract {
                Id= contractUpdateModel.Id,
                HourlyRate = contractUpdateModel.HourlyRate,
                IsActive = contractUpdateModel.IsActive,
                UserId = contractUpdateModel.UserId,
                WorkingHour = contractUpdateModel.WorkingHour
            };

            await _repository.Update(contract);
            return await _repository.SaveChangesAsync();
        }
    }
}
