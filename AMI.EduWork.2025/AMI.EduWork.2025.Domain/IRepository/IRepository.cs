using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Domain.IRepository
{
    public interface IRepository<T> where T : class
    {
        void Create(T entity);
        void Delete(string id);
        Task<T> GetById(string id);
        void Update(T entity);
        Task<IEnumerable<T>> GetAll();
    }
}
