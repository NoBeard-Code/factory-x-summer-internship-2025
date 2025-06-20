using AMI.EduWork._2025.Domain.Models.ContractModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Domain.Interfaces.Service
{
    public interface IContractService
    {
        Task<bool> Create(ContractCreateModel contractCreateModel);
        Task<bool> Delete(string id);
        Task<bool> Update(ContractUpdateModel contractUpdateModel);
        Task<ContractGetByIdModel> GetById(string id);
    }
}
