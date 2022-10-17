using System.Linq.Expressions;
using TodoList.Core.Entities.Abstract;

namespace TodoList.Core.Services
{
    public interface IService<T> where T : BaseEntity, IEntity, new()
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> CreateAsync(T entity);
        Task<IEnumerable<T>> CreateRangeAsync(IEnumerable<T> entities);
        T Update(T entity);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
        Task<IEnumerable<T>> WhereAsync(Expression<Func<T, bool>> predicate);
        Task<T> FindByConditionAsync(Expression<Func<T, bool>> predicate);
    }
}