namespace TodoList.Core.DTOs.Concrete
{
    public class UserWithTodoDto : UserDto
    {
        public ICollection<TodoDto>? Todos { get; set; }
    }
}