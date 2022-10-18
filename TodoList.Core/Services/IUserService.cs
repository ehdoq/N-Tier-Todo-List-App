using TodoList.Core.DTOs.Concrete;
using TodoList.Core.DTOs.CustomResponse;
using TodoList.Core.Entities.Concrete;

namespace TodoList.Core.Services
{
    public interface IUserService : IService<User>
    {
        Task<CustomResponseDto<UserWithTodoDto>> GetWithTodosByIdAsync(int id);
    }
}