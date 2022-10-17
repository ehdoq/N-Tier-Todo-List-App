using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TodoList.Core.Entities.Abstract;
using TodoList.Core.Repositories;
using TodoList.Repository.AppDBContexts;

namespace TodoList.Repository.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, IEntity, new()
    {
        public readonly AppDbContext _appDbcontext;
        public readonly DbSet<T> _dbSet;

        public Repository(AppDbContext context)
        {
            _appDbcontext = context;
            _dbSet = _appDbcontext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task CreateRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }
       
        public T Update(T entity)
        {
            _appDbcontext.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public async Task<IEnumerable<T>> WhereAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<T> FindByConditionAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.SingleOrDefaultAsync(predicate);
        }
    }
}