using AMI.EduWork.Domain.Models.ContractModel;

namespace AMI.EduWork.Domain.Interfaces.Service
{
    public interface IContractService
    {
        Task<bool> Create(ContractCreateModel contractCreateModel);
        Task<bool> Delete(string id);
        Task<bool> Update(ContractUpdateModel contractUpdateModel);
        Task<ContractGetModel> GetById(string id);
        Task<IEnumerable<ContractGetModel>> GetAll();
        Task<IEnumerable<ContractGetModel>> GetByHourlyRate(int hourlyRate);
        Task<IEnumerable<ContractGetModel>> GetByIsActive();
    }
}
