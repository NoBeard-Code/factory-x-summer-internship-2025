namespace AMI.EduWork.Domain.IRepository.Repository
{
    public interface IRepository<T> where T : class
    {
        Task Create(T entity);
        Task Delete(string id);
        Task<T> GetById(string id);
        Task Update(T entity);
        Task<IEnumerable<T>> GetAll();
        Task<bool> SaveChangesAsync();
    }
}
