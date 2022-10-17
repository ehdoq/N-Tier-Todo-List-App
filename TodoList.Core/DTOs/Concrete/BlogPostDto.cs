using System.ComponentModel.DataAnnotations;
using TodoList.Core.DTOs.Abstract;

namespace TodoList.Core.DTOs.Concrete
{
    public class BlogPostDto : BaseEntityDto, IEntityDto
    {
        [Required]
        public string? Title { get; set; }
        public string? Content { get; set; }
    }
}