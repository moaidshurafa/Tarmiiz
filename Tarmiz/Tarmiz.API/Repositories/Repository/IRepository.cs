using System.Linq.Expressions;

namespace Tarmiz.API.Repositories.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
        Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool tracked = true, string? includeProperties = null);
        Task AddAsync(T entity);
        Task RemoveAsync(T entity);
        Task SaveAsync();
    }
}
