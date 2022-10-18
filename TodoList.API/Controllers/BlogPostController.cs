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
    public class BlogPostController : CustomBaseController
    {
        private readonly IBlogPostService _blogPostService;
        private readonly IMapper _mapper;

        public BlogPostController(IBlogPostService BlogPostService, IMapper mapper)
        {
            _blogPostService = BlogPostService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var datas = _mapper.Map<IEnumerable<BlogPostDto>>(await _blogPostService.GetAllAsync());
            return CreateActionResult(CustomResponseDto<IEnumerable<BlogPostDto>>.Success(200, datas));
        }

        [HttpGet("{id}"), ServiceFilter(typeof(NotFoundFilter<BlogPost>))]
        public async Task<IActionResult> GetById(int id)
        {
            var data = _mapper.Map<BlogPostDto>(await _blogPostService.GetByIdAsync(id));
            return CreateActionResult(CustomResponseDto<BlogPostDto>.Success(200, data));
        }

        [HttpPost]
        public async Task<IActionResult> Create(BlogPostDto BlogPostDto)
        {
            await _blogPostService.CreateAsync(_mapper.Map<BlogPost>(BlogPostDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpPut]
        public IActionResult Update(BlogPostDto BlogPostDto)
        {
            _blogPostService.Update(_mapper.Map<BlogPost>(BlogPostDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}"), ServiceFilter(typeof(NotFoundFilter<BlogPost>))]
        public async Task<IActionResult> Delete(int id)
        {
            _blogPostService.Delete(await _blogPostService.GetByIdAsync(id));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}