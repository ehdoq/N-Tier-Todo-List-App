using System.ComponentModel.DataAnnotations;

namespace TodoList.Core.DTOs.Concrete
{
    public class UserDto
    {
        [Required]
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}