using TodoList.Core.Entities.Concrete;
using TodoList.Core.Repositories;
using TodoList.Core.Services;
using TodoList.Core.UnitOfWorks;

namespace TodoList.Service.Services
{
    public class TodoService : Service<Todo>, ITodoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TodoService(IRepository<Todo> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Todo> GetWithUserByIdAsync(int id)
        {
            return await _unitOfWork.Todo.GetWithUserByIdAsync(id);
        }
    }
}