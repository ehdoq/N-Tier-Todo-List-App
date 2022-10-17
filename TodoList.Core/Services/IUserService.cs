using TodoList.Core.Entities.Concrete;

namespace TodoList.Core.Services
{
    public interface IUserService : IService<User>
    {
        Task<User> GetWithTodosByIdAsync(int id);
    }
}