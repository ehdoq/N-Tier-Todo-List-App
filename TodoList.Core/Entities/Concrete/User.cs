using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using TodoList.Core.Entities.Abstract;

namespace TodoList.Core.Entities.Concrete
{
    [Table("Users", Schema = "dbo")]
    public class User : BaseEntity, IEntity
    {
        public User()
        {
            Todos = new Collection<Todo>();
        }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public ICollection<Todo>? Todos { get; set; }
    }
}