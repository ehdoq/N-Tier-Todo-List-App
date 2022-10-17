using TodoList.Core.Entities.Concrete;

namespace TodoList.Core.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetWithTodosByIdAsync(int id);
    }
}