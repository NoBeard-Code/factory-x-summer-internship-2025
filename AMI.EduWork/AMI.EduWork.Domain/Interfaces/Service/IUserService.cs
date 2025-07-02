using AMI.EduWork.Domain.Models.User;

namespace AMI.EduWork.Domain.Interfaces.Service;

public interface IUserService
{
    Task<bool> Delete(string id);
    Task<bool> Update(GetUserModel entity);
    Task<GetUserModel> GetById(string id);
    Task<IEnumerable<GetUserModel>> GetAll();
}
