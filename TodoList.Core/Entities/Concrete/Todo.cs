using System.ComponentModel.DataAnnotations.Schema;
using TodoList.Core.Entities.Abstract;

namespace TodoList.Core.Entities.Concrete
{
    [Table("Todos", Schema = "dbo")]
    public class Todo : BaseEntity, IEntity
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime Date { get; set; }
        public bool IsDone { get; set; }
        public int UserId { get; set; }
        public virtual User? User { get; set; }
    }
}