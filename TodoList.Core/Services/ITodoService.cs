using TodoList.Core.Entities.Concrete;

namespace TodoList.Core.Services
{
    public interface ITodoService : IService<Todo>
    {
        Task<Todo> GetWithUserByIdAsync(int id);
    }
}