using AMI.EduWork._2025.Domain.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Data.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context; 
        protected readonly DbSet<T> _dbSet;
        protected Repository(ApplicationDbContext context) { 
            _context = context; 
            _dbSet = context.Set<T>(); 
        }

        public async virtual void Create(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async virtual void Delete(string id)
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

        public async virtual void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
