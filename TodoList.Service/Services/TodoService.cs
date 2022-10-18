using AutoMapper;
using TodoList.Core.DTOs.Concrete;
using TodoList.Core.DTOs.CustomResponse;
using TodoList.Core.Entities.Concrete;
using TodoList.Core.Repositories;
using TodoList.Core.Services;
using TodoList.Core.UnitOfWorks;

namespace TodoList.Service.Services
{
    public class TodoService : Service<Todo>, ITodoService
    {
        private readonly ITodoRepository _todoRepository;
        private readonly IMapper _mapper;

        public TodoService(IRepository<Todo> repository, IUnitOfWork unitOfWork, ITodoRepository todoRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _todoRepository = todoRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<TodoWithUserDto>> GetWithUserByIdAsync(int id)
        {
            var todo = await _todoRepository.GetWithUserByIdAsync(id);
            var todoWithUserDto = _mapper.Map<TodoWithUserDto>(todo);

            return CustomResponseDto<TodoWithUserDto>.Success(200, todoWithUserDto);
        }
    }
}