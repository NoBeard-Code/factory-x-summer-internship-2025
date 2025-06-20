using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Domain.IRepository.Repository
{
    public interface IRepository<T> where T : class
    {
        Task Create(T entity);
        Task Delete(string id);
        Task<T> GetById(string id);
        Task Update(T entity);
        Task<IEnumerable<T>> GetAll();
        Task SaveChangesAsync();
    }
}
