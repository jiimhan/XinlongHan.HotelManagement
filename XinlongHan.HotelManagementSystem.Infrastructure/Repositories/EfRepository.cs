using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using XinlongHan.HotelManagementSystem.ApplicationCore.RepositoryInterfaces;
using XinlongHan.HotelManagementSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace XinlongHan.HotelManagementSystem.Infrastructure.Repositories
{
    public class EfRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly HotelManagementDbContext _dbContext;
        public EfRepository(HotelManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> Add(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<T> GetById(int id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);
            return entity;
        }

        public Task<T> GetByQuery(string queryString)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<int> GetCount(Expression<Func<T, bool>> filter)
        {
            return await _dbContext.Set<T>().Where(filter).CountAsync();
        }

        public virtual async Task<bool> GetExists(Expression<Func<T, bool>> filter)
        {
            return await _dbContext.Set<T>().Where(filter).AnyAsync();
        }

        public virtual async Task<IEnumerable<T>> List(Expression<Func<T, bool>> filter)
        {
            return await _dbContext.Set<T>().Where(filter).ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> ListAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public virtual async Task<T> Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
