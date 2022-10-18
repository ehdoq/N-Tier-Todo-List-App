using AutoMapper;
using TodoList.Core.DTOs.Concrete;
using TodoList.Core.DTOs.CustomResponse;
using TodoList.Core.Entities.Concrete;
using TodoList.Core.Repositories;
using TodoList.Core.Services;
using TodoList.Core.UnitOfWorks;

namespace TodoList.Service.Services
{
    public class UserService : Service<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IRepository<User> repository, IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<UserWithTodoDto>> GetWithTodosByIdAsync(int id)
        {
            var user = await _userRepository.GetWithTodosByIdAsync(id);
            var userWithTodoDto = _mapper.Map<UserWithTodoDto>(user);

            return CustomResponseDto<UserWithTodoDto>.Success(200, userWithTodoDto);
        }
    }
}