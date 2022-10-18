using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoList.Core.DTOs.Concrete;
using TodoList.Core.DTOs.CustomResponse;
using TodoList.Core.Entities.Concrete;
using TodoList.Core.Services;
using TodoList.Extension.Filters;

namespace TodoList.API.Controllers
{
    [Authorize]
    public class UsersController : CustomBaseController
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = _mapper.Map<IEnumerable<UserDto>>(await _userService.GetAllAsync());
            return CreateActionResult(CustomResponseDto<IEnumerable<UserDto>>.Success(200, users));
        }

        [HttpGet("{id}"), ServiceFilter(typeof(NotFoundFilter<User>))]
        public async Task<IActionResult> GetById(int id)
        {
            var user = _mapper.Map<UserDto>(await _userService.GetByIdAsync(id));
            return CreateActionResult(CustomResponseDto<UserDto>.Success(200, user));
        }

        [HttpGet("{id}/Todo"), ServiceFilter(typeof(NotFoundFilter<User>))]
        public async Task<IActionResult> GetWithTodoByIdAsync(int id)
        {
            return CreateActionResult(await _userService.GetWithTodosByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserDto userDto)
        {
            await _userService.CreateAsync(_mapper.Map<User>(userDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpPut]
        public IActionResult Update(UserDto userDto)
        {
            _userService.Update(_mapper.Map<User>(userDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}"), ServiceFilter(typeof(NotFoundFilter<User>))]
        public async Task<IActionResult> Delete(int id)
        {
            _userService.Delete(await _userService.GetByIdAsync(id));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}