using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace XinlongHan.HotelManagementSystem.ApplicationCore.RepositoryInterfaces
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> GetById(int id);

        Task<T> GetByQuery(string queryString);

        Task<IEnumerable<T>> ListAll();
        Task<IEnumerable<T>> List(Expression<Func<T, bool>> filter);
        Task<int> GetCount(Expression<Func<T, bool>> filter);
        Task<bool> GetExists(Expression<Func<T, bool>> filter);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task Delete(T entity);
    }
}
