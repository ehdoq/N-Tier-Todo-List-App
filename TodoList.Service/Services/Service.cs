using System.Linq.Expressions;
using TodoList.Core.Entities.Abstract;
using TodoList.Core.Repositories;
using TodoList.Core.Services;
using TodoList.Core.UnitOfWorks;

namespace TodoList.Service.Services
{
    public class Service<T> : IService<T> where T : BaseEntity, IEntity, new()
    {
        private readonly IRepository<T> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public Service(IRepository<T> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<T> CreateAsync(T entity)
        {
            _repository.CreateAsync(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> CreateRangeAsync(IEnumerable<T> entities)
        {
            _repository.CreateRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            return entities;
        }
        
        public T Update(T entity)
        {
            T updateEntity = _repository.Update(entity);
            _unitOfWork.Commit();
            return updateEntity;
        }

        public void Delete(T entity)
        {
            _repository.Delete(entity);
            _unitOfWork.Commit();
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _repository.DeleteRange(entities);
            _unitOfWork.Commit();
        }

        public async Task<IEnumerable<T>> WhereAsync(Expression<Func<T, bool>> predicate)
        {
            return await _repository.WhereAsync(predicate);
        }

        public async Task<T> FindByConditionAsync(Expression<Func<T, bool>> predicate)
        {
            return await _repository.FindByConditionAsync(predicate);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _repository.AnyAsync(predicate);
        }
    }
}