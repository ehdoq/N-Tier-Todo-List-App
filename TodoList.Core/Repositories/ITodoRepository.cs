using TodoList.Core.Entities.Concrete;

namespace TodoList.Core.Repositories
{
    public interface ITodoRepository : IRepository<Todo>
    {
        Task<Todo> GetWithUserByIdAsync(int id);
    }
}