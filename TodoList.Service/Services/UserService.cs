using TodoList.Core.Entities.Concrete;
using TodoList.Core.Repositories;
using TodoList.Core.Services;
using TodoList.Core.UnitOfWorks;

namespace TodoList.Service.Services
{
    public class UserService : Service<User>, IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IRepository<User> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> GetWithTodosByIdAsync(int id)
        {
            return await _unitOfWork.User.GetWithTodosByIdAsync(id);
        }
    }
}