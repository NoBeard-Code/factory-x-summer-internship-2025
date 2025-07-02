using AMI.EduWork._2025.Domain.Interfaces.Repository;
using AMI.EduWork._2025.Domain.Interfaces.Service;
using AMI.EduWork._2025.Domain.Models.ContractModel;
using AMI.EduWork._2025.Domain.Models.User;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace AMI.EduWork._2025.Domain.Services
{
    public class ContractService : IContractService
    {
        private readonly IContractRepository _repository;
        private readonly ILogger<ContractService> _logger;
        public ContractService(IContractRepository repository, ILogger<ContractService> logger)
        {
            _logger = logger;
            _repository = repository;
        }
        public async Task<bool> Create(ContractCreateModel? contractCreateModel)
        {
            if (contractCreateModel is null) return false;
            Entities.Contract contract = new Entities.Contract {
                Id = Guid.NewGuid().ToString(),
                HourlyRate = contractCreateModel.HourlyRate,
                IsActive = contractCreateModel.IsActive,
                WorkingHour = contractCreateModel.WorkingHour,
                UserId = contractCreateModel.UserId,
                Created = DateOnly.FromDateTime(DateTime.Now)
            };
            await _repository.Create(contract);    
            return await _repository.SaveChangesAsync();
        }

        public async Task<bool> Delete(string id)
        {
            await _repository.Delete(id);
            return await _repository.SaveChangesAsync();
        }

        public async Task<ContractGetModel> GetById(string id)
        {
            Entities.Contract contract = await _repository.GetById(id);
            ContractGetModel contractGetByIdModel = new ContractGetModel {
                Id = contract.Id,
                HourlyRate = contract.HourlyRate,
                IsActive= contract.IsActive,
                Created = DateOnly.FromDateTime(DateTime.Now),
                WorkingHour = contract.WorkingHour,
                _GetUserModel = new GetUserModel{
                    Id = contract.UserId,
                    AccessFailedCount = contract.User.AccessFailedCount,
                    Email = contract.User.Email,
                    Role = contract.User.Role,
                    TwoFactorEnabled = contract.User.TwoFactorEnabled,
                    EmailConfirmed = contract.User.EmailConfirmed,
                    LockoutEnabled = contract.User.LockoutEnabled,
                    LockoutEnd = contract.User.LockoutEnd,
                    NormalizedEmail = contract.User.NormalizedEmail,
                    NormalizedUserName = contract.User.NormalizedUserName,
                    PhoneNumber = contract.User.PhoneNumber,
                    PhoneNumberConfirmed = contract.User.PhoneNumberConfirmed,
                    UserName = contract.User.UserName
                }
            };
            return contractGetByIdModel;
        }

        public async Task<IEnumerable<ContractGetModel>> GetByIsActive()
        {
            IEnumerable<Entities.Contract> contract = await _repository.GetAll();
            IEnumerable<ContractGetModel> contractGetByIdModel = contract.
                Where(x => x.IsActive).
                Select(x => new ContractGetModel
                {
                    Id = x.Id,
                    HourlyRate= x.HourlyRate,
                    IsActive = x.IsActive,
                    Created = DateOnly.FromDateTime(DateTime.Now),
                    WorkingHour = x.WorkingHour,
                    _GetUserModel = new GetUserModel
                    {
                        Id = x.UserId,
                        AccessFailedCount = x.User.AccessFailedCount,
                        Email = x.User.Email,
                        Role = x.User.Role,
                        TwoFactorEnabled = x.User.TwoFactorEnabled,
                        EmailConfirmed = x.User.EmailConfirmed,
                        LockoutEnabled = x.User.LockoutEnabled,
                        LockoutEnd = x.User.LockoutEnd,
                        NormalizedEmail = x.User.NormalizedEmail,
                        NormalizedUserName = x.User.NormalizedUserName,
                        PhoneNumber = x.User.PhoneNumber,
                        PhoneNumberConfirmed = x.User.PhoneNumberConfirmed,
                        UserName = x.User.UserName
                    }
                });

            return contractGetByIdModel;
        }

        public async Task<IEnumerable<ContractGetModel>> GetByHourlyRate(int hourlyRate)
        {
            IEnumerable<Entities.Contract> contract = await _repository.GetAll();
            IEnumerable<ContractGetModel> contractGetByIdModel = contract.
                Where(x => x.HourlyRate.Equals(hourlyRate)).
                Select(x => new ContractGetModel
                {
                    Id = x.Id,
                    HourlyRate = x.HourlyRate,
                    Created = DateOnly.FromDateTime(DateTime.Now),
                    IsActive = x.IsActive,
                    WorkingHour = x.WorkingHour,
                    _GetUserModel = new GetUserModel
                    {
                        Id = x.UserId,
                        AccessFailedCount = x.User.AccessFailedCount,
                        Email = x.User.Email,
                        Role = x.User.Role,
                        TwoFactorEnabled = x.User.TwoFactorEnabled,
                        EmailConfirmed = x.User.EmailConfirmed,
                        LockoutEnabled = x.User.LockoutEnabled,
                        LockoutEnd = x.User.LockoutEnd,
                        NormalizedEmail = x.User.NormalizedEmail,
                        NormalizedUserName = x.User.NormalizedUserName,
                        PhoneNumber = x.User.PhoneNumber,
                        PhoneNumberConfirmed = x.User.PhoneNumberConfirmed,
                        UserName = x.User.UserName
                    }
                });

            return contractGetByIdModel;
        }
        public async Task<IEnumerable<ContractGetModel>> GetByWorkingHour(int workingHour)
        {
            IEnumerable<Entities.Contract> contract = await _repository.GetAll();
            IEnumerable<ContractGetModel> contractGetByIdModel = contract.
                Where(x => x.WorkingHour.Equals(workingHour)).
                Select(x => new ContractGetModel
                {
                    Id = x.Id,
                    HourlyRate = x.HourlyRate,
                    IsActive = x.IsActive,
                    Created = DateOnly.FromDateTime(DateTime.Now),
                    WorkingHour = x.WorkingHour,
                    _GetUserModel = new GetUserModel
                    {
                        Id = x.UserId,
                        AccessFailedCount = x.User.AccessFailedCount,
                        Email = x.User.Email,
                        Role = x.User.Role,
                        TwoFactorEnabled = x.User.TwoFactorEnabled,
                        EmailConfirmed = x.User.EmailConfirmed,
                        LockoutEnabled = x.User.LockoutEnabled,
                        LockoutEnd = x.User.LockoutEnd,
                        NormalizedEmail = x.User.NormalizedEmail,
                        NormalizedUserName = x.User.NormalizedUserName,
                        PhoneNumber = x.User.PhoneNumber,
                        PhoneNumberConfirmed = x.User.PhoneNumberConfirmed,
                        UserName = x.User.UserName
                    }
                });

            return contractGetByIdModel;
        }
        public async Task<IEnumerable<ContractGetModel>> GetAll()
        {
            IEnumerable<Entities.Contract> contract = await _repository.GetAll();
            IEnumerable<ContractGetModel> contractGetByIdModel = contract.Select(x => new ContractGetModel
                {
                    Id = x.Id,
                    HourlyRate = x.HourlyRate,
                    IsActive = x.IsActive,
                    Created = DateOnly.FromDateTime(DateTime.Now),
                    WorkingHour = x.WorkingHour,
                    _GetUserModel = new GetUserModel
                    {
                        Id = x.UserId,
                        AccessFailedCount = x.User.AccessFailedCount,
                        Email = x.User.Email,
                        Role = x.User.Role,
                        TwoFactorEnabled = x.User.TwoFactorEnabled,
                        EmailConfirmed = x.User.EmailConfirmed,
                        LockoutEnabled = x.User.LockoutEnabled,
                        LockoutEnd = x.User.LockoutEnd,
                        NormalizedEmail = x.User.NormalizedEmail,
                        NormalizedUserName = x.User.NormalizedUserName,
                        PhoneNumber = x.User.PhoneNumber,
                        PhoneNumberConfirmed = x.User.PhoneNumberConfirmed,
                        UserName = x.User.UserName
                    }
            });

            return contractGetByIdModel;
        }

        public async Task<bool> Update(ContractUpdateModel? contractUpdateModel)
        {
            if (contractUpdateModel is null) return false;

            Entities.Contract contract = await _repository.GetById(contractUpdateModel.Id);
            contract.HourlyRate = contractUpdateModel.HourlyRate;
            contract.IsActive = contractUpdateModel.IsActive;
            contract.UserId = contractUpdateModel.UserId;
            contract.WorkingHour = contractUpdateModel.WorkingHour;
            contract.Created = contractUpdateModel.Created;

            await _repository.Update(contract);
            return await _repository.SaveChangesAsync();
        }
    }
}
