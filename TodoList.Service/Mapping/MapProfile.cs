using AutoMapper;
using TodoList.Core.DTOs.Concrete;
using TodoList.Core.Entities.Concrete;

namespace TodoList.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Todo, TodoDto>().ReverseMap();
            CreateMap<Todo, TodoWithUserDto>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserWithTodoDto>().ReverseMap();

            CreateMap<BlogPost, BlogPostDto>().ReverseMap();
        }
    }
}