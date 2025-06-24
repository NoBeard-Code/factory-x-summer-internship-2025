using AMI.EduWork._2025.Domain.Models.User;

namespace AMI.EduWork._2025.Domain.Interfaces.Service;

public interface IUserService
{
    Task<bool> Delete(string id);
    Task<bool> Update(GetUserModel entity);
    Task<GetUserModel> GetById(string id);
    Task<IEnumerable<GetUserModel>> GetAll();
}
