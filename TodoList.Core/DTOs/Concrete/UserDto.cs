using System.ComponentModel.DataAnnotations;
using TodoList.Core.DTOs.Abstract;

namespace TodoList.Core.DTOs.Concrete
{
    public class UserDto : BaseEntityDto, IEntityDto
    {
        [Required]
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}