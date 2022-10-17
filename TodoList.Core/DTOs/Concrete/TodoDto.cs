using System.ComponentModel.DataAnnotations;
using TodoList.Core.Entities.Concrete;

namespace TodoList.Core.DTOs.Concrete
{
    public class TodoDto
    {
        [Required]
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime Date { get; set; }
        public bool IsDone { get; set; }
        public int UserId { get; set; }
    }
}