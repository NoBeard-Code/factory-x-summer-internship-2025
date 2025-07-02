using AMI.EduWork.Domain.IRepository.Repository;
using Microsoft.EntityFrameworkCore;

namespace AMI.EduWork.Data.Repository;

public abstract class Repository<T> : IRepository<T> where T : class
{
    protected readonly ApplicationDbContext _context; 
    protected readonly DbSet<T> _dbSet;
    protected Repository(ApplicationDbContext context) { 
        _context = context; 
        _dbSet = context.Set<T>(); 
    }

    public async virtual Task Create(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public async virtual Task Delete(string id)
    {
        T? entity =  await _dbSet.FindAsync(id);
        if (entity != null) _dbSet.Remove(entity);
    }

    public async virtual Task<IEnumerable<T>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }

    public async virtual Task<T> GetById(string id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async virtual Task<bool> SaveChangesAsync()
    {
       return await _context.SaveChangesAsync()>0;
    }

    public async virtual Task Update(T entity)
    {
        _dbSet.Update(entity);
    }
}
