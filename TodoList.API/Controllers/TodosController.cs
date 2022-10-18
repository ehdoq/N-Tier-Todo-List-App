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
    public class TodosController : CustomBaseController
    {
        private readonly ITodoService _todoService;
        private readonly IMapper _mapper;

        public TodosController(ITodoService todoService, IMapper mapper)
        {
            _todoService = todoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var todos = _mapper.Map<IEnumerable<TodoDto>>(await _todoService.GetAllAsync());
            return CreateActionResult(CustomResponseDto<IEnumerable<TodoDto>>.Success(200, todos));
        }

        [HttpGet("{id}"), ServiceFilter(typeof(NotFoundFilter<Todo>))]
        public async Task<IActionResult> GetById(int id)
        {
            var todo = _mapper.Map<TodoDto>(await _todoService.GetByIdAsync(id));
            return CreateActionResult(CustomResponseDto<TodoDto>.Success(200, todo));
        }

        [HttpGet("{id}/User"), ServiceFilter(typeof(NotFoundFilter<Todo>))]
        public async Task<IActionResult> GetWithUserByIdAsync(int id)
        {
            return CreateActionResult(await _todoService.GetWithUserByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(TodoDto todoDto)
        {
            await _todoService.CreateAsync(_mapper.Map<Todo>(todoDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpPut]
        public IActionResult Update(TodoDto todoDto)
        {
            _todoService.Update(_mapper.Map<Todo>(todoDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}"), ServiceFilter(typeof(NotFoundFilter<Todo>))]
        public async Task<IActionResult> Delete(int id)
        {
            _todoService.Delete(await _todoService.GetByIdAsync(id));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}