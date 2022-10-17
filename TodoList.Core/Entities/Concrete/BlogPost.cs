using System.ComponentModel.DataAnnotations.Schema;
using TodoList.Core.Entities.Abstract;

namespace TodoList.Core.Entities.Concrete
{
    [Table("BlogPosts", Schema = "dbo")]
    public class BlogPost : BaseEntity, IEntity
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
    }
}