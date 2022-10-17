namespace TodoList.Core.DTOs.Concrete
{
    public class TodoWithUserDto : TodoDto
    {
        public UserDto? User { get; set; }
    }
}