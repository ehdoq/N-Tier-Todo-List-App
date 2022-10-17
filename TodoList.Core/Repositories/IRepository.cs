using System.Linq.Expressions;
using TodoList.Core.Entities.Abstract;

namespace TodoList.Core.Repositories
{
    public interface IRepository<T> where T : BaseEntity, IEntity, new()
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task CreateAsync(T entity);
        Task CreateRangeAsync(IEnumerable<T> entities);
        T Update(T entity);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
        Task<IEnumerable<T>> WhereAsync(Expression<Func<T, bool>> predicate);
        Task<T> FindByConditionAsync(Expression<Func<T, bool>> predicate);
    }
}