using TodoList.Core.DTOs.Concrete;
using TodoList.Core.DTOs.CustomResponse;
using TodoList.Core.Entities.Concrete;

namespace TodoList.Core.Services
{
    public interface ITodoService : IService<Todo>
    {
        Task<CustomResponseDto<TodoWithUserDto>> GetWithUserByIdAsync(int id);
    }
}